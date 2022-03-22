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


        private static List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
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
        [HttpGet("Id/{Id}", Name ="GetNote")]
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
            if(note == null)
            {
                return BadRequest("Note can't be null");
            }
            _notes.Add(note);
            //return Ok(_notes);
            return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
        }

        /// <summary>
        /// Update a note by given id.
        /// If id not found create that note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }
            int index = _notes.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                return CreateNotes(note);
                //return NotFound("Index not found");
            }
            note.Id = id;
            _notes[index] = note;
            return Ok(_notes);
        }

        /// <summary>
        /// Delete a note by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            int index = _notes.FindIndex(n => n.Id == id);
            if(index == -1)
            {
                return NotFound("Note not found");
            }
            _notes.RemoveAt(index);
            return Ok("Note deleted");
        }

        /// <summary>
        /// Update a note by id and OwnerId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idOwner"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}, {idOwner}")]
        public IActionResult UpdateNoteByIdAndOwnerId(Guid id, Guid idOwner, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }
            int index = _notes.FindIndex(n => n.Id == id && n.OwnerId == idOwner);
            if (index == -1)
            {
                return CreateNotes(note);
                //return NotFound("Index not found");
            }
            note.Id = id;
            note.OwnerId = idOwner;
            _notes[index] = note;
            return Ok(_notes);
        }

        /// <summary>
        /// Delete a note by id and ownerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id},{ownerId}")]
        public IActionResult DeleteNoteByIdAndOwnerId(Guid id, Guid ownerId)
        {
            int index = _notes.FindIndex(n => n.Id == id && n.OwnerId == ownerId);
            if (index == -1)
            {
                return NotFound("Note not found");
            }
            _notes.RemoveAt(index);
            return Ok("Note deleted");
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteAllNotesByOwnerId(Guid id)
        //{
        //    List<Note> note = new List<Note>();
            
        //    _notes.RemoveAll(n => n.OwnerId == id);
        //    return Ok("Note deleted");
        //}



    }
}
