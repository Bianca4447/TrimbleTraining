import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdComponent } from './third/third.component';



@NgModule({
  declarations: [
    ThirdComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ThirdComponent
  ]
})
export class Module2Module { }
