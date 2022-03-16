import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../category';
import { FilterServiceService } from '../services/filter-service.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  @Output() emitSelectedFilter=new EventEmitter<string>();
  categories:Category[];
  

  constructor(private service: FilterServiceService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategory();
  }

  selectFilter(categoryId: string){
    this.emitSelectedFilter.emit(categoryId);
  }



}
