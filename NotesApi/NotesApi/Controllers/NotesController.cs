using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApi.Services;

namespace NotesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteCollectionService _noteCollectionService;
        
        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ?? 
                throw new ArgumentNullException(nameof(noteCollectionService));

        }

        /// <summary>
        /// Get list of notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteCollectionService.GetAll());

        }

        ///// <summary>
        ///// Return a note by ownerId 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public IActionResult GetNoteByOwnerId(Guid id)
        //{
        //    return Ok(_noteCollectionService.GetNotesByOwnerId(id));
        //}

        /// <summary>
        /// Return a note by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Id/{Id}", Name = "GetNote")]
        public async Task<IActionResult> GetNoteByIdAsync(Guid Id)
        {
            return Ok(await _noteCollectionService.Get(Id));
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNotes([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }
            if (note.Id == Guid.Empty)
            {
                note.Id = Guid.NewGuid();
            }
            await _noteCollectionService.Create(note);
            
            return Ok(await _noteCollectionService.GetAll());
        }

        /// <summary>
        /// Update a note by given id.
        /// If id not found create that note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }
            if (! await _noteCollectionService.Update(id, note))
            {
                await _noteCollectionService.Create(note);
                return NotFound("The note don't exist");
            }
            return Ok(await _noteCollectionService.GetAll());
        }

        /// <summary>
        /// Delete a note by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteAsync(Guid id)
        {
            bool ok = await _noteCollectionService.Delete(id);
            if (!ok)
            {
                return NotFound("Note not found");
            }
            return Ok("Note deleted");
        }

        ///// <summary>
        ///// Update a note by id and OwnerId
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="idOwner"></param>
        ///// <param name="note"></param>
        ///// <returns></returns>
        //[HttpPut("{id}, {idOwner}")]
        //public IActionResult UpdateNoteByIdAndOwnerId(Guid id, Guid idOwner, [FromBody] Note note)
        //{
        //    if (note == null)
        //    {
        //        return BadRequest("Note can't be null");
        //    }
        //    int index = _notes.FindIndex(n => n.Id == id && n.OwnerId == idOwner);
        //    if (index == -1)
        //    {
        //        return CreateNotes(note);
        //        //return NotFound("Index not found");
        //    }
        //    note.Id = id;
        //    note.OwnerId = idOwner;
        //    _notes[index] = note;
        //    return Ok(_notes);
        //}

        ///// <summary>
        ///// Delete a note by id and ownerId
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id},{ownerId}")]
        //public IActionResult DeleteNoteByIdAndOwnerId(Guid id, Guid ownerId)
        //{
        //    int index = _notes.FindIndex(n => n.Id == id && n.OwnerId == ownerId);
        //    if (index == -1)
        //    {
        //        return NotFound("Note not found");
        //    }
        //    _notes.RemoveAt(index);
        //    return Ok("Note deleted");
        //}

        ////[HttpDelete("{id}")]
        ////public IActionResult DeleteAllNotesByOwnerId(Guid id)
        ////{
        ////    List<Note> note = new List<Note>();

        ////    _notes.RemoveAll(n => n.OwnerId == id);
        ////    return Ok("Note deleted");
        ////}



    }
}
