import { Component, Input, OnInit, Output } from '@angular/core';
import { Note } from '../note';
import NoteService from '../services/note.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  categoryId: string;

  // @Input() wordTexted: string;
  // @Output() wordSearch: string;

  
  constructor() { }

  ngOnInit(): void {
 
  }

  receiveCategory(categId: string) {
    this.categoryId = categId;
  }

  // wordChanged($event): void {
  //   this.wordSearch = this.wordTexted;
  // }

}
