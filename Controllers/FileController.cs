using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GradeSheetCreator.Controllers
{
    [Route("Files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("Font/{filename}")]
        public IActionResult GetFont([FromRoute] string filename) {
            string filePath = $"./Assets/{filename}";
            byte[] fileContents = System.IO.File.ReadAllBytes(filePath);
            string contentType = "font/ttf";
            return File(fileContents, contentType, filename);
        }
        [HttpGet("Image/{filename}")]
        public IActionResult GetImage([FromRoute] string filename) {
            string filePath = $"./Assets/{filename}";
            byte[] fileContents = System.IO.File.ReadAllBytes(filePath);
            string contentType = "image/png";
            return File(fileContents, contentType, filename);
        }
    }
}