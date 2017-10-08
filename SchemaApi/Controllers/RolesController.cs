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
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/roles
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _unitOfWork.RoleRepository.GetAll();
        }

        // GET api/roles/5
        [HttpGet("{id}")]
        public Role Get(Guid id)
        {
            return _unitOfWork.RoleRepository.GetById(id);
        }

        // POST api/roles
        [HttpPost]
        public void Post([FromBody]Role value)
        {
            _unitOfWork.RoleRepository.Add(value);
            _unitOfWork.Commit();
        }

        // PUT api/roles/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Role value)
        {
            _unitOfWork.RoleRepository.Update(value);
            _unitOfWork.Commit();
        }

        // DELETE api/roles/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unitOfWork.RoleRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
