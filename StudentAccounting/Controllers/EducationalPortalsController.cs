﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Controllers
{
    public class EducationalPortalsController : Controller
    {
        private readonly IEducationalPortalsService _educationalPortalsService;
        public EducationalPortalsController(IEducationalPortalsService educationalPortalsService)
        {
            _educationalPortalsService = educationalPortalsService;
        }
        [Authorize]
        [HttpGet("GetEducationalPortals")]
        public ActionResult<IEnumerable<EducationalPortals>> Get()
        {
            try
            {
                return Ok(_educationalPortalsService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idEducationalPortals/{id}", Name = "GetEducationalPortalsId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_educationalPortalsService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameEducationalPortals/{name}", Name = "GetEducationalPortals")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_educationalPortalsService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateEducationalPortals")]
        public IActionResult Create(EducationalPortals educationalPortals)
        {
            try
            {
                _educationalPortalsService.Create(educationalPortals);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateEducationalPortals")]
        public IActionResult Update(EducationalPortals educationalPortals)
        {
            try
            {
                _educationalPortalsService.Edit(educationalPortals);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteEducationalPortals")]
        public IActionResult Delete(int id)
        {
            try
            {
                _educationalPortalsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
