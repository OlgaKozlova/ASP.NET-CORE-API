using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User value)
        {
            _unitOfWork.UserRepository.Add(value);
            _unitOfWork.Commit();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            _unitOfWork.UserRepository.Update(value);
            _unitOfWork.Commit();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
