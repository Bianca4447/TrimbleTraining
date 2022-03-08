import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'notes-app';
  text = "text";
  dateTest: Date = new Date(5,5,2000);
  myValue : number = 10;
}
