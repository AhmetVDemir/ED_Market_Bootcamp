using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        IAirplaneService _apService;
        public AirplanesController(IAirplaneService apservice)
        {

            _apService = apservice;

        }

        [HttpGet("getall")]
        public IActionResult Get() 
        {
            Thread.Sleep(1000);

            var result = _apService.GetAll();
            if (result._Success)
            {
                
                return Ok(result);
            }
                


            return BadRequest(result._Message);
        }

        [HttpPost("add")]
        public IActionResult Post(Airplane adAir)
        {
            var result = _apService.AddAirplane(adAir);

            if (result._Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var resul = _apService.GetById(id);
            if (resul._Success)
                return Ok(resul);
            return BadRequest(resul);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var resul = _apService.GetAllByCategoryId(categoryId);
            if (resul._Success)
                return Ok(resul);
            return BadRequest(resul);
        }

    }
}
