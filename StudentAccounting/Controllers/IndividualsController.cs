﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Implementations;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Common.ModelsDto;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class IndividualsController : Controller
    {
        private readonly IIndividualsService _individualsService;
        public IndividualsController(IIndividualsService individualsService)
        {
            _individualsService = individualsService;
        }
        [HttpGet("GetIndividuals")]
        public ActionResult<IEnumerable<IndividualsDto>> Get()
        {
            return Ok(_individualsService.Get());
        }
        [HttpGet("GetIndividual")]
        public IActionResult Get(string name)
        {
            return Ok(_individualsService.Get(name));
        }
        [HttpPost("CreateIndividual")]
        public IActionResult Create(IndividualsDto newIndividuals)
        {
            _individualsService.Create(newIndividuals);
            return Ok();
        }
        [HttpPut("UpdateIndividual")]
        public IActionResult Update(IndividualsDto newIndividuals)
        {
            _individualsService.Edit(newIndividuals);
            return Ok();
        }
        [HttpDelete("DeletIndividual")]
        public IActionResult Delete(int id)
        {
            _individualsService.Delete(id);
            return Ok();
        }
    }
}
