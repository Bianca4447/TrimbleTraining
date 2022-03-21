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
    public class NotesController : ControllerBase
    {
        static List<Note> _notes = new List<Note> { new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "First Note", Description = "First Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fifth Note", Description = "Fifth Note Description" }
        };


        /// <summary>
        /// Get list of notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }

        /// <summary>
        /// Return a note by ownerId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetNoteByOwnerId(Guid id)
        {
            var note = _notes.FirstOrDefault(n => n.OwnerId == id);
            return Ok(note);
        }

        /// <summary>
        /// Return a note by a given Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Id/{Id}")]
        public IActionResult GetNoteById(Guid Id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == Id);
            return Ok(note);
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNotes([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(_notes);
            // return CreatedAtRoute("GetNoteById", new { id = note.Id }, note);
        }



    }
}
