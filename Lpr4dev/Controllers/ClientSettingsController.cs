using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSwag.Annotations;
using Lpr4dev.ApiModel;
using Lpr4dev.Server.Settings;

namespace Lpr4dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSettingsController : Controller
    {
        private readonly IOptions<ClientOptions> clientOptions;

        public ClientSettingsController(IOptions<ClientOptions> clientOptions)
        {
            this.clientOptions = clientOptions;
        }

        /// <summary>
        /// Gets client settings for the lpr4dev UI.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, typeof(ClientSettings), Description = "")]
        public ApiModel.ClientSettings Get()
        {
            var clientProps = clientOptions.Value;
            return new ApiModel.ClientSettings
            {
                PageSize = clientProps.PageSize
            };
        }
    }
}