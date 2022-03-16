import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs';
import { Category } from '../category';
import { Note } from '../note';
import { FilterServiceService } from '../services/filter-service.service';
import NoteService from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  isOnEdit: boolean;
  idNote: string;
  category: Category;
  categories: Category[];

  notesForm: FormGroup;
 

   constructor(
     private noteService: NoteService, 
     private route: ActivatedRoute, 
     private filterService: FilterServiceService,
     private formBuilder: FormBuilder
     ) { }

  ngOnInit(): void {
    this.categories = this.filterService.getCategory();
    this.route.queryParams.subscribe(
      (param) => {
        this.idNote = param['IdNote'];
        if(this.idNote) {
          this.isOnEdit = true;
        }
        else {
          this.isOnEdit = false;
        }
      }
    );
    this.pageType();
  }

  pageType() {
    if (this.isOnEdit) {
      this.noteService
        .getNotes()
        .pipe(
          map((notes) => notes.filter((note) => note.id === this.idNote)[0])
        )
        .subscribe((noteToEdit) => {
          this.category = this.categories.filter(
            (category) => category.id === noteToEdit.categoryId
          )[0];
          this.detailNote(noteToEdit);
        });
    } else {
      this.category = this.categories[0];
      this.detailNote({
        id: Guid.create().toString(),
        title: '',
        description: '',
        categoryId: '',
      });
    }
  }

  public get titleValid() {
    return this.notesForm.get('title');
  }

  public get descriptionValid() {
    return this.notesForm.get('description');
  }

  public get categoryValid() {
    return this.notesForm.get('category');
  }

  detailNote(note: Note) {
    this.notesForm = this.formBuilder.group(
      {
          id: note.id,
          title: [note.title, Validators.required],
          description: [note.description, Validators.required],
          category: this.category
      }
    );
  }

  addNote(){
    const note: Note = {
      id: this.notesForm.get("id").value,
      title: this.notesForm.get("title").value,
      description: this.notesForm.get("description").value,
      categoryId: this.notesForm.get("category").value.id
    }

    if(this.isOnEdit) {
      this.noteService.editNote(note);
    }
    else if(!this.isOnEdit){
      this.noteService.addNoteClick(note);
    }
  }

 


}
