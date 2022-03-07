import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  title:string="This is a simple text";
  colorContent:string = "";
  text:string = "";
  textColor:string = "";

  constructor() { }

  ngOnInit(): void {
  }

  isValidColor(colorContent: string): boolean{
    var s = new Option().style;
    var test = /^#[0-9A-F]{6}$/i.test(colorContent);
    s.color = colorContent;
    return s.color == colorContent || test == true;
  }

  setBackgroundColor(){
    var color = this.isValidColor(this.text);
    if(color == true){
      this.colorContent = this.text;
    }else{
      alert("This is not a valid color");
    }
  }

  setTitle(){
    this.textColor = this.colorContent;
  }

}
