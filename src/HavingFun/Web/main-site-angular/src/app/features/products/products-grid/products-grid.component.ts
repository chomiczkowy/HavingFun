import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PageableQuery } from 'src/app/models/queries/pageable-query';
import { ProductQueryItem } from 'src/app/models/products/product-query-item';
import { PageableQueryResult } from 'src/app/models/queries/pageable-query-result';

@Component({
  selector: 'app-products-grid',
  templateUrl: './products-grid.component.html',
  styleUrls: ['./products-grid.component.scss']
})
export class ProductsGridComponent implements OnInit {

  @Input()
  private results: PageableQueryResult<ProductQueryItem>;

  @Input()
  private query: PageableQuery;
  
  
  @Output()
  private queryChanged:EventEmitter<PageableQuery>=new EventEmitter<PageableQuery>();

  constructor() { }

  ngOnInit() {
  }

  pageChanged(event:{page:number, rows:number}){
    ///TODO: Is there an interface type for event data?
    console.log('pageChanged');
    this.query.pageNumber=event.page;
    this.query.pageSize=event.rows;

    this.queryChanged.emit(this.query);
  }

}
