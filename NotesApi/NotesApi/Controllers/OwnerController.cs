using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        static List<Owner> _owners = new List<Owner>
        {
           new Owner{Id=Guid.NewGuid(), Name="Client1"},
           new Owner{Id=Guid.NewGuid(), Name="Client2"},
           new Owner{Id=Guid.NewGuid(), Name="Client3"},
           new Owner{Id=Guid.NewGuid(), Name="Client4"},
        };

        /// <summary>
        /// Get the list of owners
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOwner()
        {
            return Ok(_owners);
        }

        /// <summary>
        /// Update an owner by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner can't be null");
            }

            int index = _owners.FindIndex(o => o.Id == id);
            if(index == -1)
            {
                return NotFound("Owner not found");
            }
            
            _owners[index].Id = id;
            _owners[index] = owner;

            return Ok(_owners);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            int index = _owners.FindIndex(o => o.Id == id);
            if (index == -1)
            {
                return NotFound("Owner not found");
            }
            _owners.RemoveAt(index);
            return Ok(_owners);
        }
    }
}
