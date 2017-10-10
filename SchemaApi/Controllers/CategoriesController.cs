using Domain.Contracts;
using Domain.Contracts.Repositories;
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
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private const string _name = "Category";

        public CategoriesController(IUnitOfWork unitOfWork, ILogger<CategoriesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET api/categories
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_unitOfWork.CategoryRepository.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }            
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var Category = _unitOfWork.CategoryRepository.GetById(id);
                if (Category != null)
                {
                    return Ok(_unitOfWork.CategoryRepository.GetById(id));
                }
                return NotFound();
                
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // POST api/categories
        [HttpPost]
        public IActionResult Post([FromBody]Category value)
        {
            try
            {
                _unitOfWork.CategoryRepository.Add(value);
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

        // PUT api/categories/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Category value)
        {
            try
            {
                _unitOfWork.CategoryRepository.Update(value);
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
                return StatusCode(500, e.Message);
            }
            
        }

        // DELETE api/categories/5
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
