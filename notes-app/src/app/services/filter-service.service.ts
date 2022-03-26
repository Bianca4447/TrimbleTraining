import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Category } from '../category';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export class FilterServiceService {

  categories: Category[] =[
    {name:'To do', id:'1'},
    {name:'Done', id:'2'},
    {name:'Doing', id:'3'}
  ]

  readonly baseUrl= "http://localhost:5001";
  
  readonly httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
  })
};

  constructor(private httpClient: HttpClient) { }

  getCategory(){
    return this.categories;
  }

  getCategoryById(number:string){
   
    return this.categories.find((category)=>category.id=number);

  }

  getFilteredNotes(categId: string): Observable<Note[]> {
    return this.httpClient
      .get<Note[]>(
        this.baseUrl + `/notes`,
        this.httpOptions
      )
      .pipe(
        map((notes) => notes.filter((note) => note.categoryId === categId))
      );
  }
}
