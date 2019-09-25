import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PageableQuery } from 'src/app/models/queries/pageable-query';

@Component({
  selector: 'app-products-grid',
  templateUrl: './products-grid.component.html',
  styleUrls: ['./products-grid.component.scss']
})
export class ProductsGridComponent implements OnInit {

  @Input()
  private query: PageableQuery;
  
  
  @Output()
  private queryChanged:EventEmitter<PageableQuery>=new EventEmitter<PageableQuery>();

  constructor() { }

  ngOnInit() {
  }

}
