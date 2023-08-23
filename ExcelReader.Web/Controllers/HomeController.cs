
using ExcelReader.Web.Models;
using ExcelReader.Web.Repository;
using FastExcel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace ExcelReader.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _environment;
        private IRepository _excelReader;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment, IRepository excelReader)
        {
            _logger = logger;
            _environment = environment;
            _excelReader = excelReader;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private string UploadFile(IFormFile formFile)
        {
            string uploadpath = _environment.WebRootPath;
            string finalPath = Path.Combine(uploadpath, "uploaded_files");

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }
            string sourcefile = Path.GetFileName(formFile.FileName);
            string path = Path.Combine(finalPath, sourcefile);

            using (FileStream filestream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(filestream);
            }
            return path;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("file/upload")]
        public async Task<IActionResult> UploadEntries()
        {
            if (!HttpContext.Request.Form.Files.Any()) return Json(new ResponseMessage
            {
                hasError = true,
                message = "You did not upload a valid file"
            });

            try
            {
                var file = HttpContext.Request.Form.Files[0];

                var allowedFiles = new string[] { ".xlsx", ".xls" };
                var fileExt = Path.GetExtension(file.FileName);

                if (!allowedFiles.Contains(fileExt)) return Json(new ResponseMessage
                {
                    hasError = true,
                    message = "You did not upload a valid file"
                });

                var inputFile = new FileInfo(UploadFile(file));

                var fileUpload = await _excelReader.ReadExcelFile(inputFile);
                if (fileUpload)
                {
                    return Json(new ResponseMessage
                    {
                        hasError = false,
                        message = "File upladed successfully"
                    });
                }
                else
                {
                    return Json(new ResponseMessage
                    {
                        hasError = true,
                        message = "File upload failed"
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }




        }



        [HttpPost]
        [Route("people")]
        public IActionResult ListAllPeople()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var peopleQuery = _excelReader.GetAllPersons();

            recordsTotal = peopleQuery.Count();

            var recordList = peopleQuery.OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = recordList
            });
        }



        [HttpPost]
        [Route("books")]
        public IActionResult ListAllBook()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _excelReader.GetAllBooks();

            recordsTotal = query.Count();

            var recordList = query.OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = recordList
            });
        }

        [HttpPost]
        [Route("schools")]
        public IActionResult ListAllSchool()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _excelReader.GetAllSchools();

            recordsTotal = query.Count();

            var recordList = query.OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = recordList
            });
        }


    }
}