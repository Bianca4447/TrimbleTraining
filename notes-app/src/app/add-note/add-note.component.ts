import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../category';
import { Note } from '../note';
import { FilterServiceService } from '../services/filter-service.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title:string;
  description:string;
  selectedCategoryId: string;
  categories: Category[];

  constructor(private noteService:NoteService, private route:Router, private filterService: FilterServiceService) { }

  ngOnInit(): void {
    this.categories = this.filterService.getCategory();
  }

  addNote(){
    var addNoteToNotes:Note = {
      id: Math.random().toString(),
      title: this.title,
      description: this.description
    }
    this.noteService.addNote(addNoteToNotes);
    this.route.navigate(['']);
  }

 


}
