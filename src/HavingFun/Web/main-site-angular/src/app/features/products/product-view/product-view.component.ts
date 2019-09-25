import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { ProductRichModel } from 'src/app/models/products/product-rich-model';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit {
  private productId:number;
  private model: ProductRichModel={
    id:0,
    name:'',
    description:''
  };

  constructor(private activatedRoute:ActivatedRoute, private productService:ProductService, private router:Router) {
    activatedRoute.paramMap.subscribe(x=> {
      this.productId=parseInt(x.get('productId'));
      if(this.productId>0){
        this.getCurrentProduct();
      }else{
          router.navigate(['error/notFound']);
      }
    })
   }

  ngOnInit() {
  }

  getCurrentProduct(){
    this.productService.getProductById(this.productId).subscribe(model=>{
      this.model=model;
    });
  }

}
