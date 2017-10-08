using Domain.Contracts;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public Category Get(Guid id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody]Category value)
        {
            _unitOfWork.CategoryRepository.Add(value);
            _unitOfWork.Commit();
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Category value)
        {
            _unitOfWork.CategoryRepository.Update(value);
            _unitOfWork.Commit();
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
