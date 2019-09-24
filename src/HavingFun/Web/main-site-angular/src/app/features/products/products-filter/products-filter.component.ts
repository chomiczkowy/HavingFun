import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCategoryTreeItem } from 'src/app/models/products/product-category-tree-item';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';
import { ProductListSearchFilter } from 'src/app/models/products/product-list-search-filter';

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.scss']
})
export class ProductsFilterComponent implements OnInit {
  @Input()
  private filter:ProductListSearchFilter;

  @Output()
  private filterChanged:EventEmitter<ProductListSearchFilter>=new EventEmitter<ProductListSearchFilter>();

  private productCategories:ProductCategoryTreeItem[]=[];
  private selectedProductCategories:ProductCategoryTreeItem[]=[];

  constructor(private productService:ProductService, 
              private router:Router) { }

  ngOnInit() {
    this.productService.getProductCategoriesForTree().subscribe(
      categories => {
        for(var i=0;i<categories.length;i++){
          this.setUpIcons(categories[i]);
        }
        this.productCategories = categories;
      });
}

setUpIcons(category:ProductCategoryTreeItem){
  category.collapsedIcon="fa fa-folder";
  category.expandedIcon="fa fa-folder-open";

  if(category.children){
    for(var i=0;i<category.children.length;i++){
      this.setUpIcons(category.children[i]);
    }
  }
}

nodeSelect(event) {
    console.log(event);
    var selectedProductCategoriesIds=this.selectedProductCategories.map(x=> x.data);
    this.filter.categoriesIds=selectedProductCategoriesIds;
    this.filterChanged.emit(this.filter);
}

}
