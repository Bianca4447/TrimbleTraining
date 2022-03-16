import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export default class NoteService {
  

readonly baseUrl= "https://localhost:4200";
readonly httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
  })
};


constructor(private httpClient: HttpClient, private router: Router) { }



getNotes():Observable<Note[]> {
  return this.httpClient.get<Note[]>(
    this.baseUrl+'/notes', 
    this.httpOptions
    );
}

// getSearch(wordSearch: string):Observable<Note[]> {
//     wordSearch = wordSearch.toLowerCase();

//     return this.httpClient.get<Note[]>(
//       this.baseUrl+'/notes', 
//       this.httpOptions
//     )
//     .pipe(
//       map((note:Note[]) => {
//         return note.filter(
//           note => note.title.toLowerCase().includes(wordSearch) || note.description.toLowerCase().includes(wordSearch)
//         );
//       })
//     )
// }

addNoteClick(note: Note){
  let notes= {  
                id: note.id,
                title: note.title,
                description: note.description,
                category: note.categoryId
                
              }
  return  this.httpClient.post(this.baseUrl+"/notes", notes, this.httpOptions);
}

deleteNote(id: string) {
  return this.httpClient.delete(this.baseUrl + '/notes/' + id);
}

editNote(note: Note){
  return this.httpClient.put(this.baseUrl + "/notes?id="+ note.id, note).subscribe(
    response => {
      this.router.navigate(['notes']);
    },
    (e:HttpErrorResponse) => console.log(e)
  );
}

}
