import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatButtonModule} from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldControl, MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from "@angular/material/card";
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import { TestComponent } from './test/test.component';
import { AddValuePipe } from './add-value.pipe';
import { FilterComponent } from './filter/filter.component';
import { AddNoteComponent } from './add-note/add-note.component';
import { HomeComponent } from './home/home.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpMockApiInterceptor } from './services/http-mock-api.interceptor';




@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    TestComponent,
    AddValuePipe,
    FilterComponent,
    AddNoteComponent,
    HomeComponent
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatCardModule,
    CommonModule, 
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
 
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpMockApiInterceptor,
      multi: true
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
