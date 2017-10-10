﻿using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemaApi.Controllers
{
    [Route("api/[controller]")]
    public class SchemasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private const string _name = "Schema";

        public SchemasController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET api/schemas
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_unitOfWork.SchemaRepository.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // GET api/schemas/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var Schema = _unitOfWork.SchemaRepository.GetById(id);
                if (Schema != null)
                {
                    return Ok(_unitOfWork.SchemaRepository.GetById(id));
                }
                return NotFound();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // POST api/schemas
        [HttpPost]
        public IActionResult Post([FromBody]Schema value)
        {
            try
            {
                _unitOfWork.SchemaRepository.Add(value);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                return BadRequest($@"{_name} is not valid");
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // PUT api/schemas/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Schema value)
        {
            try
            {
                _unitOfWork.SchemaRepository.Add(value);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                return BadRequest($@"{_name} is not valid");
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // DELETE api/schemas/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _unitOfWork.SchemaRepository.Delete(id);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
