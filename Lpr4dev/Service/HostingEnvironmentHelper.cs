﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Lpr4dev.Server.Settings;

namespace Lpr4dev.Service
{
    public interface IHostingEnvironmentHelper
    {
        string GetEditableSettingsFilePath();
        bool IsRunningInContainer();

        bool SettingsAreEditable { get; }
    }

    public class HostingEnvironmentHelper : IHostingEnvironmentHelper
    {
        private readonly IHostEnvironment hostEnvironment;
        private readonly IOptionsMonitor<CommandLineOptions> commandLineOptions;
        private readonly IOptionsMonitor<ServerOptions> serverOptions;

        public HostingEnvironmentHelper(IHostEnvironment hostEnvironment, IOptionsMonitor<ServerOptions> serverOptions, IOptionsMonitor<CommandLineOptions> commandLineOptions)
        {
            this.hostEnvironment = hostEnvironment;
            this.commandLineOptions = commandLineOptions;
            this.serverOptions = serverOptions;
        }

        /// <summary>
        /// Check if this process is running on Windows in an in process instance in IIS
        /// </summary>
        /// <returns>True if Windows and in an in process instance on IIS, false otherwise</returns>
        private static bool IsRunningInProcessIIS()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return false;
            }

            var processName = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().ProcessName);
            return (processName.Contains("w3wp", StringComparison.OrdinalIgnoreCase) ||
                    processName.Contains("iisexpress", StringComparison.OrdinalIgnoreCase));
        }

        public bool IsRunningInContainer()
        {
            return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
        }

        public bool SettingsAreEditable
        {
            get
            {
                if (serverOptions.CurrentValue.LockSettings)
                {
                    return false;
                }

                string editableSettingsFile = GetEditableSettingsFilePath();
                if (string.IsNullOrEmpty(editableSettingsFile))
                {
                    return false;
                }

                if (File.Exists(editableSettingsFile))
                {
                    try
                    {
                        //Test file can be opened in write mode
                        File.OpenWrite(editableSettingsFile).Close();
                        return true;
                    }
                    catch (IOException)
                    {
                        return false;
                    }
                }

                //Settings file does not exist yet. Test access to write a file to the parent dir
                string settingsFolder = Path.GetDirectoryName(editableSettingsFile);
                if (!Directory.Exists(settingsFolder))
                {
                    return false;
                }

                string testFileName;
                do
                {
                    testFileName = Path.Combine(settingsFolder, Guid.NewGuid().ToString());
                } while (File.Exists(testFileName));

                try
                {
                    File.OpenWrite(testFileName).Close();
                    File.Delete(testFileName);
                    return true;
                }
                catch (IOException)
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Get path to appsettings.json to which settings changed at runtime should be saved.
        /// For IIS this is inside the runtime directory.
        /// </summary>
        /// <returns>appsettings.json filePath</returns>
        public string GetEditableSettingsFilePath()
        {
            string dataDir;

            if (IsRunningInProcessIIS())
            {
                dataDir = Path.Join(hostEnvironment.ContentRootPath, "lpr4dev");
            }
            else if (commandLineOptions.CurrentValue.NoUserSettings)
            {
                return null;
            }
            else
            {
                dataDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "lpr4dev");
            }
            return Path.Join(dataDir, "appsettings.json");
        }
    }
}