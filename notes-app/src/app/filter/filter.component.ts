import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
import { FilterServiceService } from '../services/filter-service.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories:Category[];
  

  constructor(private service: FilterServiceService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategory();
  }



}
