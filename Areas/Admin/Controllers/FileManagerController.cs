using elFinder.NetCore;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        IWebHostEnvironment _env;
        public FileManagerController(IWebHostEnvironment env) => _env = env;

        [Route("Admin/connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            return await connector.ProcessAsync(Request);
        }

        // Địa chỉ để truy vấn thumbnail
        // /el-finder-file-system/thumb
        [Route("Admin/thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = GetConnector();
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            string pathroot = "wwwroot/uploads";
            string requestUrl = "uploads";

            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            string rootDirectory = Path.Combine(_env.ContentRootPath, pathroot);

            string url = $"/{requestUrl}/";
            string urlthumb = $"{uri.Scheme}://{uri.Authority}/Admin/thumb/";

            var root = new RootVolume(rootDirectory, url, urlthumb)
            {
                IsReadOnly = false,
                IsLocked = false,
                Alias = "Files",
                //MaxUploadSizeInKb = 2048, 
                ThumbnailSize = 100,
            };
            driver.AddRoot(root);
            return new Connector(driver)
            {
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }
}
