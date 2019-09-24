import { Component, OnInit, Input } from '@angular/core';
import { ProductListSearchFilter } from 'src/app/models/products/product-list-search-filter';

@Component({
  selector: 'app-products-grid',
  templateUrl: './products-grid.component.html',
  styleUrls: ['./products-grid.component.scss']
})
export class ProductsGridComponent implements OnInit {

  @Input()
  private filter: ProductListSearchFilter;
  
  constructor() { }

  ngOnInit() {
  }

}
