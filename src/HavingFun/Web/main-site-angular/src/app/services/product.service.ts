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
    const params:HttpParams=new HttpParams({
      fromObject:{
        categoriesIds: query.categoriesIds.map(x=>x.toString()),
        pageSize: query.pageSize.toString(),
        pageNumber: query.pageNumber.toString(),
        sortField:query.sortField,
        isDescending:query.isDescending.toString()

      }
    });

    return this.http.get<PageableQueryResult<ProductQueryItem>>(environment.shopApiUrl+"products", {
      params: params
    });
  }
}
