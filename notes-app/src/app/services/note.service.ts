import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export default class NoteService {
  

readonly baseUrl= "http://localhost:5001";
readonly httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

readonly headers = new HttpHeaders({'Content-Type':'application/json; charset=utf-8'});

constructor(private httpClient: HttpClient, private router: Router) { 
}



getNotes():Observable<Note[]> {
  return this.httpClient.get<Note[]>(this.baseUrl+'/notes', this.httpOptions);
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
  // let notes= {  
  //               title: note.title,
  //               description: note.description,
  //               category: note.categoryId
                
  //             }
          
  return  this.httpClient.post(this.baseUrl+"/notes", note).subscribe(
    response => {
      this.router.navigate(['notes'])
    }
  );
}

deleteNote(id: string) {

  return this.httpClient.delete(this.baseUrl + '/notes/' + id);
 
}

editNote(note: Note){
  return this.httpClient.put(this.baseUrl + "/notes?id="+ note.id, note).subscribe(response => {
      this.router.navigate(['notes'])
  })


}

}
