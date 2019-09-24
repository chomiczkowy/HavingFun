import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductListSearchFilter } from 'src/app/models/products/product-list-search-filter';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  
  private filter:ProductListSearchFilter={categoriesIds:[]};

  constructor() { 
  }

  ngOnInit() {

  }

  onFilterChanged(newFilter: ProductListSearchFilter){
    this.filter=newFilter;
  }
}
