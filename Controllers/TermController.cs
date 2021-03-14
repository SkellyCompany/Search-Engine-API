﻿using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Core.ApplicationServices;
using SearchEngine.API.Core.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TermController : Controller
    {
        private readonly ITermService _service;

        public TermController(ITermService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentsForASpecificTerm([FromQuery] Request request)
        {
            Console.WriteLine("I was hit badly");
            var result = await _service.Search(request);
            if (result != null && result.Documents.Any())
                return Ok(result.Documents);
            else
                //return BadRequest(new { Message = "Aww, come on Greg..." });
                return NoContent();
        }
    }
}