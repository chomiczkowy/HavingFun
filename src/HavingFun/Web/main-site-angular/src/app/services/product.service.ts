import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ProductCategoryTreeItem } from '../models/products/product-category-tree-item';
import { environment } from 'src/environments/environment';
import { ProductListSearchQuery } from '../models/products/product-list-search-query';
import { ProductQueryItem } from '../models/products/product-query-item';
import { PageableQueryResult } from '../models/queries/pageable-query-result';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getProductCategoriesForTree(){  
      return this.http.get<ProductCategoryTreeItem[]>(environment.shopApiUrl + "productCategories/tree");
   
  }

  findByQuery(query:ProductListSearchQuery){
    var params:HttpParams=new HttpParams();
    for(let key in query){
      params.set(key.toString(), query[key]);
    }

    return this.http.get<PageableQueryResult<ProductQueryItem>>(environment.shopApiUrl+"products", {
      params: params
    });
  }
}
