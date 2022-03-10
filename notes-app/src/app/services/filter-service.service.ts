import { Injectable } from '@angular/core';
import { Category } from '../category';

@Injectable({
  providedIn: 'root'
})
export class FilterServiceService {

  categories: Category[] =[
    {name:'To do', id:'1'},
    {name:'Done', id:'2'},
    {name:'Doing', id:'3'}
  ]

  constructor() { }

  getCategory(){
    return this.categories;
  }

  getCategoryById(number:string){
    return this.categories.find((category)=>category.id=number);

  }
}
