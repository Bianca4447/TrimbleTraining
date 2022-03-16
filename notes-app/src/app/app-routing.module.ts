import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { HomeComponent } from './home/home.component';

const routes:Routes=[
  { path: "", component: HomeComponent, pathMatch:"full" },
  { path: "add-note", component: AddNoteComponent},
  { path: '**', redirectTo: ''}
  
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
