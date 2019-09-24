import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { ProductCategoryTreeItem } from 'src/app/models/products/product-category-tree-item';

@Component({
  selector: 'app-shop-main',
  templateUrl: './shop-main.component.html',
  styleUrls: ['./shop-main.component.scss']
})
export class ShopMainComponent implements OnInit {

  private productCategories:ProductCategoryTreeItem[];
  
  constructor(private productService:ProductService) { }

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
    //event.node = selected node
}

}
