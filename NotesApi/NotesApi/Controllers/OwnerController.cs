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

        [HttpGet]
        public IActionResult GetOwner()
        {
            return Ok(_owners);
        }
    }
}
