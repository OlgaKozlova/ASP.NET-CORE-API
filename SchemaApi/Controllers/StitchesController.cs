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
    public class StitchesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StitchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/stitches
        [HttpGet]
        public IEnumerable<Stitch> Get()
        {
            return _unitOfWork.StitchRepository.GetAll();
        }

        // GET api/stitches/5
        [HttpGet("{id}")]
        public Stitch Get(Guid id)
        {
            return _unitOfWork.StitchRepository.GetById(id);
        }

        // POST api/stitches
        [HttpPost]
        public void Post([FromBody]Stitch value)
        {
            _unitOfWork.StitchRepository.Add(value);
            _unitOfWork.Commit();
        }

        // PUT api/stitches/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Stitch value)
        {
            _unitOfWork.StitchRepository.Update(value);
            _unitOfWork.Commit();
        }

        // DELETE api/stitches/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unitOfWork.StitchRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
