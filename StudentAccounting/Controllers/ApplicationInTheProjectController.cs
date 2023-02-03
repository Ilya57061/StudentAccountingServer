﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.BusinessLogic.Services.Contracts;

namespace StudentAccounting.Controllers
{
    [Authorize]
    public class ApplicationInTheProjectController : Controller
    {
        private readonly IApplicationInTheProjectService _applicationInTheProjectService;

        public ApplicationInTheProjectController(IApplicationInTheProjectService applicationInTheProjectService)
        {
            _applicationInTheProjectService = applicationInTheProjectService;
        }
        [Authorize(Roles = "User")]
        [HttpGet("GetAppInTheProject")]
        public ActionResult<IEnumerable<ApplicationsInTheProject>> Get()
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("idAppInTheProject/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_applicationInTheProjectService.Get(id));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="GlobalPm")]
        [HttpPost("CreateAppInTheProject")]
        public IActionResult Create(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Create(applicationsInTheProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [Authorize]
        [HttpPut("UpdateAppInTheProject")]
        public IActionResult Update(ApplicationsInTheProject applicationsInTheProject)
        {
            try
            {
                _applicationInTheProjectService.Edit(applicationsInTheProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="LocalPm")]
        [HttpDelete("DeleteAppInTheProject")]
        public IActionResult Delete(int id)
        {
            try
            {
                _applicationInTheProjectService.Delete(id);
                return Ok();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
