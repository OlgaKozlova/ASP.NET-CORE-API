using Domain.Contracts;
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
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private const string _name = "Role";

        public RolesController(IUnitOfWork unitOfWork, ILogger<RolesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET api/roles
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_unitOfWork.RoleRepository.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // GET api/roles/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var Role = _unitOfWork.RoleRepository.GetById(id);
                if (Role != null)
                {
                    return Ok(_unitOfWork.RoleRepository.GetById(id));
                }
                return NotFound();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            
        }

        // POST api/roles
        [HttpPost]
        public IActionResult Post([FromBody]Role value)
        {
            try
            {
                _unitOfWork.RoleRepository.Add(value);
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

        // PUT api/roles/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Role value)
        {
            try
            {
                _unitOfWork.RoleRepository.Add(value);
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

        // DELETE api/roles/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _unitOfWork.CategoryRepository.Delete(id);
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
