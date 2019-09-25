import { Component, OnInit } from '@angular/core';
import { ProductListSearchQuery } from 'src/app/models/products/product-list-search-query';
import { PageableQuery } from 'src/app/models/queries/pageable-query';
import { PageableQueryResult } from 'src/app/models/queries/pageable-query-result';
import { ProductQueryItem } from 'src/app/models/products/product-query-item';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  
  private query: ProductListSearchQuery={
    categoriesIds:[],
    pageNumber:0,
    pageSize:10,
    sortField:'',
    isDescending:false
  };

  private results:PageableQueryResult<ProductQueryItem>={
    allItemsCount:0,
    items:[]
  };

  constructor(private productService: ProductService) { 
  }

  ngOnInit() {

  }

  onQueryChanged(newQuery: ProductListSearchQuery){
    this.query=newQuery;

    this.search();
  }

  onGridQueryChanged(newQuery:PageableQuery){
    this.query.sortField=newQuery.sortField;
    this.query.isDescending=newQuery.isDescending;
    this.query.pageNumber=newQuery.pageNumber;
    this.query.pageSize=newQuery.pageSize;

    this.search();
  }

  search(){
    this.productService.findByQuery(this.query).subscribe((results)=>{
      this.results=results;
    });
  }
}
