/* Web 服务器通常会将进入的 URL 请求直接映射到服务器上的磁盘文件。
 * 例如：URL 请求 "http://www.w3cschool.cc/index.php" 将直接映射到服务器根目录上的文件 "index.php"。
 * MVC 框架的映射方式有所不同。MVC 将 URL 映射到 方 法 。这些方法在类中被称为"控制器"。
 * 控制器负责处理进入的请求，处理输入，保存数据，并把响应发送回客户端。  2022-01-30 */  
using LIMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


using Oracle.ManagedDataAccess.Client;

namespace LIMS.Controllers
{
    public class HomeController : Controller
    {
        //日志记录相关 - 开始
        //可以搜一下ILogger用法，Log这个词就是表示跟日志有关的   2022-02-01
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //日志记录相关 - 结束


        /*整个程序的入口*/
        public IActionResult Index()
        {
            string ConnectionString = ConnectionHelper.OracleString;
            //using OracleConnection conn = new OracleConnection(ConnectionString);
            //conn.Open();
            return View();
        }

        public IActionResult Onborrow()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}