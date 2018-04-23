using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using MyNetCore.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;

namespace MyNetCore.Controllers
{
    public class HomeController : Controller
    {
        private TestService _testService;
        private IHostingEnvironment _hostingEnvironment;
        private IMemoryCache _memoryCache;
        private ILogger _logger;
        public HomeController(TestService testService,IHostingEnvironment hostingEnvironment, IMemoryCache memoryCache,ILoggerFactory loggerFactory)
        {
            this._testService = testService;
            this._hostingEnvironment = hostingEnvironment;
            this._memoryCache = memoryCache;
            this._logger = loggerFactory.CreateLogger(typeof (HomeController));
        }
        public IActionResult Index()
        {
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //var root = builder.Build();
            //var content = root.GetSection("Logging").GetSection("IncludeScopes").GetSection("Default").Value;
            //var userInfo = new UserInfo() {
            //     Address="北京市西城区菜市口",
            //      Age=18,
            //       Email="1715174428@qq.com",
            //        Name="张三",
            //         PhoneNum="18639670967"
            //};

            using (EfDbContext efDbContext = new EfDbContext())
            {
                _logger.LogDebug("这是一个调试信息");
                _logger.LogError("这是一个错误信息");
                _logger.LogWarning("警告");
                var user = efDbContext.UserInfos.Include(r => r.Role).First(i => i.UserId > 1 && i.RoleId == 2);
                HttpContext.Session.SetString("xingming", "zhangsan");
                _memoryCache.Set<UserInfo>("LoginUser",user,TimeSpan.FromSeconds(1000));
                return Content($"用户名称为:{user.Name},年龄为:{user.Age},地址为:{user.Address},角色为:{user.Role.Name},对你说:{_testService.SayHello()}");
            }

            //return View();

            // _memoryCache.Set<UserInfo>();
        }

        public IActionResult About()
        {
            var user = _memoryCache.Get<UserInfo>("LoginUser");
            user.Name = HttpContext.Session.GetString("xingming");
           var html= HtmlEncoder.Default.Encode("<input type='button' value ='测试' />");
            user.Address = html;
            user.Email = UrlEncoder.Default.Encode("http://www.no5.com.cn");
            return Json(user);
            //var jsonUser = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            //return Content(jsonUser);
            //ViewData["Message"] = "Your application description page.";
            ////获取本地路径
            //var rootPath=_hostingEnvironment.ContentRootPath;
            ////获取wwwroot静态文件的路径
            //var wwwPath = _hostingEnvironment.WebRootPath;
            ////拼接获取对应文件的路径
            //var sitePath = Path.Combine(wwwPath,"js/site.js");
            //var appsettingPath = Path.Combine(rootPath, "appsettings.json");
            ////是否为开发环境
            //var isDev = _hostingEnvironment.IsDevelopment();
            //return Content($"rootPath={rootPath}<br/>wwwPath={wwwPath}<br/>sitePath={sitePath}<br/>appsettingPath={appsettingPath}");
            //return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
