using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private const string _name = "Stitch";

        public UsersController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_unitOfWork.UserRepository.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var Schema = _unitOfWork.UserRepository.GetById(id);
                if (Schema != null)
                {
                    return Ok(_unitOfWork.UserRepository.GetById(id));
                }
                return NotFound();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User value)
        {
            try
            {
                _unitOfWork.UserRepository.Add(value);
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

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]User value)
        {
            try
            {
                _unitOfWork.UserRepository.Add(value);
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

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _unitOfWork.UserRepository.Delete(id);
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
