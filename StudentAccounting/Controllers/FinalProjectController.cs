﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    public class FinalProjectController : Controller
    {
        private readonly IFinalProjectService _finalProjectService;
        public FinalProjectController(IFinalProjectService finalProjectService)
        {
            _finalProjectService = finalProjectService;
        }
        [Authorize]
        [HttpGet("GetFinalProject")]
        public ActionResult<IEnumerable<FinalProject>> Get()
        {
            try
            {
                return Ok(_finalProjectService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("GetFinalProjectForEmploymentId")]
        public ActionResult GetForEmployment(int id)
        {
            try
            {
                return Ok(_finalProjectService.GetForEmployment(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idFinalProject/{id}", Name = "GetFinalProjectId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_finalProjectService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameFinalProject/{name}", Name = "GetFinalProjectName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_finalProjectService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpPost("CreateFinalProject")]
        public IActionResult Create(FinalProject finalProject)
        {
            try
            {
                _finalProjectService.Create(finalProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpPut("UpdateFinalProject")]
        public IActionResult Update(FinalProject finalProject)
        {
            try
            {
                _finalProjectService.Edit(finalProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,Director,DirectorOrganizational,GlobalPm")]
        [HttpDelete("DeleteFinalProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _finalProjectService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
