import { HttpHeaders } from '@angular/common/http';
import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Note } from '../note';
import { FilterServiceService } from '../services/filter-service.service';
import NoteService from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit,OnChanges {

  notes: Note[];
  filterNote: Note[];
  searchWord: string;

  @Input() selectedCategoryId: string;

  constructor(
     private service: NoteService, 
     private serviceFilter: FilterServiceService,
     private router: Router
  ) {}


  ngOnInit(): void {
    
    this.getNotes();

  }
  ngOnChanges():void{
   
    this.serviceFilter.getFilteredNotes(this.selectedCategoryId).subscribe((note:Note[]) => {this.notes = note})
    this.filterSearchWord();
    
  }

  getNotes(){

    this.service.getNotes().subscribe( (notes:Note[]) => {
      this.notes = notes;
      this.filterNote = notes;
    });
  }

  filterSearchWord(){
    if(this.searchWord) {
      this.notes = this.filterNote.filter((note) => (note.title.toLowerCase().includes(this.searchWord.toLowerCase())
       || note.description.toLowerCase().includes(this.searchWord.toLowerCase())));

    }
  }

  editNote(note: Note){
    this.router.navigate(['/add-note'],{
      queryParams: {IdNote: note.id}
    });
  }

  deleteNote(id: string){
    this.service.deleteNote(id).subscribe(
      (response) => {
        this.notes = this.notes.filter((note) => note.id != id);
        this.filterNote = [...this.notes];
      },
      (e) => console.log(e)
      );

  }

  }
