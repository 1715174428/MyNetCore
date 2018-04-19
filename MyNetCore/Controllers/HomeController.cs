using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using MyNetCore.Models;

namespace MyNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //var root = builder.Build();
            //var content = root.GetSection("Logging").GetSection("IncludeScopes").GetSection("Default").Value;
            var userInfo = new UserInfo() {
                 Address="北京市西城区菜市口",
                  Age=18,
                   Email="1715174428@qq.com",
                    Name="张三",
                     PhoneNum="18639670967"
            };
            using (EfDbContext efDbContext = new EfDbContext())
            {
                var user=efDbContext.UserInfos.Include(r=>r.Role).First(i=>i.UserId>1&&i.RoleId==2);
                return Content($"用户名称为:{user.Name},年龄为:{user.Age},地址为:{user.Address},角色为:{user.Role.Name}");
            }

            //return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
