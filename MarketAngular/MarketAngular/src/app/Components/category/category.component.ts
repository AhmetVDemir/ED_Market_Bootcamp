import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories : Category[] = [];
  currentCat:Category;

  constructor(private categoryService : CategoryService) { }

  ngOnInit(): void {
    this.getCategory()
  }
  getCategory(){
    this.categoryService.getCategories().subscribe(res=>{
      this.categories = res.data
    })
  }
  setCurrentCategory(kat:Category){
    this.currentCat = kat;
  }
  //css klasını değiştir
  getCurrentCategoryClass(cat:Category){
    if(cat == this.currentCat){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

}
