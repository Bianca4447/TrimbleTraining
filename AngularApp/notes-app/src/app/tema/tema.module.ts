import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Comp1Component } from './comp1/comp1.component';
import { Comp2Component } from './comp2/comp2.component';
import { FirstComponent } from './module1/first/first.component';
import { SecondComponent } from './module1/second/second.component';



@NgModule({
  declarations: [
    Comp1Component,
    Comp2Component,
    FirstComponent,
    SecondComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    Comp1Component,
    Comp2Component,
    FirstComponent,
    SecondComponent
  ]
})
export class TemaModule { }
