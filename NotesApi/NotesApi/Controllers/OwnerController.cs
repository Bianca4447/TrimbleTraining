//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using NotesApi.Models;
//using NotesApi.Services;

//namespace NotesApi.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class OwnerController : ControllerBase
//    {
//        IOwnerCollectionService _ownerService;

//        public OwnerController(IOwnerCollectionService ownerService)
//        {
//            _ownerService = ownerService ??
//                throw new ArgumentNullException(nameof(ownerService));

//        }

//        /// <summary>
//        /// Get the list of owners
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        public IActionResult GetOwner()
//        {
//            return Ok(_ownerService.GetAll());
//        }

//        /// <summary>
//        /// Update an owner by id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <param name="owner"></param>
//        /// <returns></returns>
//        [HttpPut("{id}")]
//        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
//        {
//            if (owner == null)
//            {
//                return BadRequest("Owner can't be null");
//            }

//            bool ok = _ownerService.Update(id, owner);
//            if(!ok)
//            {
//                return NotFound("Owner not found");
//            }
            
//            return Ok(_ownerService.GetAll());

//        }

//        /// <summary>
//        /// Delete an owner by id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpDelete("{id}")]
//        public IActionResult DeleteOwner(Guid id)
//        {
            
//            bool ok = _ownerService.Delete(id);
//            if (!ok)
//            {
//                return NotFound("Owner not found");
//            }
            
//            return Ok(_ownerService.GetAll());
//        }
//    }
//}
