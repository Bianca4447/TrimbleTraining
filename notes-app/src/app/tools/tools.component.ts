import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  title:string="Add note";
  titleColor:string="red";
  noteContent:string="";
  colorContent:string = "";
  
  constructor() { }

  ngOnInit(): void {
  }

  
  setTitle(){
    this.noteContent = "Note content modificat de pe buton";
  }

  setColor(){
    this.colorContent = "Color content"
  }

}
