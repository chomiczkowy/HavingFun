import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCategoryTreeItem } from 'src/app/models/products/product-category-tree-item';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';
import { ProductListSearchQuery } from 'src/app/models/products/product-list-search-query';

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.scss']
})
export class ProductsFilterComponent implements OnInit {
  @Input()
  private query:ProductListSearchQuery;

  @Output()
  private queryChanged:EventEmitter<ProductListSearchQuery>=new EventEmitter<ProductListSearchQuery>();

  private productCategories:ProductCategoryTreeItem[]=[];
  private selectedProductCategories:ProductCategoryTreeItem[]=[];

  constructor(private productService:ProductService, 
              private router:Router) { }

  ngOnInit() {
    this.productService.getProductCategoriesForTree().subscribe(
      categories => {       
        this.productCategories = categories;
      });
}

nodeSelect(event) {
    console.log(event);
    var selectedProductCategoriesIds=this.selectedProductCategories.map(x=> x.data);
    this.query.categoriesIds=selectedProductCategoriesIds;
    this.queryChanged.emit(this.query);
}

}
