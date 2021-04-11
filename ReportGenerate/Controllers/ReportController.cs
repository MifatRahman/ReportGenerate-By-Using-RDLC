using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ReportGenerate.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportController(IWebHostEnvironment webHostEnvironment) 
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Print() 
        {
            string mimtype = "";
            int extention = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rp1","Welcome to Online Class");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf,extention, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
