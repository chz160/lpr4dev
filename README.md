# <img src='Lpr4dev/ClientApp/public/logo.png' alt='logo'/>  
**lpr4dev - the fake LPR print server for development and testing.**

lpr4dev is a fork of [smtp4dev](https://github.com/rnwood/smtp4dev), originally designed for simulating SMTP servers for email testing. This project adapts the core functionality of smtp4dev to simulate a network LPR (Line Printer Remote) server, providing a similar development and testing tool for applications that require printing over a network connection.

A dummy LPR (Line Printer Remote) server for Windows, Linux, macOS (and anywhere .NET Core is supported). lpr4dev allows you to test your applications that require network printing without the need for a physical printer. Perfect for use in development and test environments, this tool simulates printer communication via port 9100, logs job data, and provides a web interface for monitoring.

### Key Features:
- **OpenAPI/Swagger API**: Interact programmatically with the simulated printer.
- **PJL Command Support**: Accepts and logs Printer Job Language (PJL) commands to simulate printer operations.
- **LPR Job Session Logging**: View details of print jobs sent to the server.
- **Job Status Overview**: Monitor active and historical print jobs through a web UI.
- **Web Interface**: View and manage job history, printer status, and other relevant information in a configurable web interface.
- **Simulated Printer Errors**: Introduce simulated printer issues (paper jams, out of toner) to test application handling.
- **Multi-Platform Support**: Run on Windows, Linux, or macOS with .NET Core compatibility.
- **TLS/SSL Support**: Optional TLS/SSL for secure communication, with auto self-signed certificate generation.
- **Configurable Ports**: Choose which port the LPR service and the web interface should run on.
- **Printer Queue Simulation**: Set up multiple virtual printers and manage their print queues.

### Getting Started

[Installation Guide](https://github.com/chz160/lpr4dev/wiki/Installation)  
   Learn how to install and set up lpr4dev for your development environment.

[Configuration Guide](https://github.com/chz160/lpr4dev/wiki/Configuration)  
   Explore how to configure the ports, printers, and web interface for your specific use case.

[Client Configuration](https://github.com/chz160/lpr4dev/wiki/Configuring-Clients)  
   Adjust your applications to send print jobs to the lpr4dev server.

[API Guide](https://github.com/chz160/lpr4dev/wiki/API)  
   Access the Swagger-based API to interact programmatically with the virtual printer.

### Screenshots

![Screenshot 1](screenshot1.png)  
_View of the web-based dashboard showing active and historical print jobs._

![Screenshot 2](screenshot2.png)  
_Configuration options for managing virtual printers and viewing logs._

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fchz160%2Flpr4dev.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fchz160%2Flpr4dev?ref=badge_shield)

### Simulated PJL Commands
lpr4dev currently supports the following PJL commands:
- `@PJL JOB NAME="jobname"`: Starts a new print job.
- `@PJL INFO STATUS`: Retrieves the simulated printer status.
- `@PJL EOJ`: Ends the current print job.
- More PJL commands are in development to enhance simulation capabilities.

### Support and Contributions

If you find lpr4dev useful, consider supporting further development:  
<a href="https://www.patreon.com/bePatron?u=38204828" data-patreon-widget-type="become-patron-button"><img alt='Become a Patreon' src='https://c5.patreon.com/external/logo/become_a_patron_button.png' height="30px"></a>  
<a href='https://www.paypal.me/chz160'><img alt='Donate' src='https://www.paypalobjects.com/webstatic/en_US/btn/btn_donate_pp_142x27.png'/></a>

Contributions, bug reports, and feature requests are welcome! Please open an issue or submit a pull request on GitHub.

### License
lpr4dev is licensed under the MIT License. See [LICENSE](LICENSE) for more details.

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fchz160%2Flpr4dev.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fchz160%2Flpr4dev?ref=badge_large)
