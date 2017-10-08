using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public SchemasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/schemas
        [HttpGet]
        public IEnumerable<Schema> Get()
        {
            return _unitOfWork.SchemaRepository.GetAll();
        }

        // GET api/schemas/5
        [HttpGet("{id}")]
        public Schema Get(Guid id)
        {
            return _unitOfWork.SchemaRepository.GetById(id);
        }

        // POST api/schemas
        [HttpPost]
        public void Post([FromBody]Schema value)
        {
            _unitOfWork.SchemaRepository.Add(value);
            _unitOfWork.Commit();
        }

        // PUT api/schemas/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Schema value)
        {
            _unitOfWork.SchemaRepository.Update(value);
            _unitOfWork.Commit();
        }

        // DELETE api/schemas/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unitOfWork.SchemaRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
