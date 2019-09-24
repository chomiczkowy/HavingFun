import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductCategoryTreeItem } from '../models/products/product-category-tree-item';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getProductCategoriesForTree(){  
      return this.http.get<ProductCategoryTreeItem[]>(environment.shopApiUrl + "productCategories/tree");
   
  }
}
