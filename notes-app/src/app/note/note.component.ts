import { Component, OnInit } from '@angular/core';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

  notes: Note[];

  constructor(
    private service: NoteService
  ) {}

  ngOnInit(): void {
    this.service.serviceCall();
    this.notes = this.service.getNotes();
  }

}
