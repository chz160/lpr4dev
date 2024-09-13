using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Lpr4dev.ApiModel;

namespace Lpr4dev.Controllers
{
    /// <summary>
    /// Returns information about the version of smtp4dev
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [UseEtagFilter]
    public class VersionController : Controller
    {
        /// <summary>
        /// Gets version infomation about smtp4dev.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<VersionInfo> Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            var infoVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            return new VersionInfo { Version = version, InfoVersion = infoVersion };
        }
    }
}