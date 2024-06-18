import { Component } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.models';
import { CategoryListComponent } from '../category-list/category-list.component';
import { CategoryService } from '../services/category.service';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [CategoryListComponent, FormsModule, RouterLink],
  templateUrl: 'add-category.component.html',
  styleUrl: 'add-category.component.css'
})
export class AddCategoryComponent {

  model: AddCategoryRequest;

constructor(private categoryService: CategoryService, private router:Router){
this.model = {
description: ' ',
imageURL: ' '
};
}

onFormSubmit(): void{
this.categoryService.addCategory(this.model)
.subscribe({
  next:(response)=>{
    console.log(response);
  }
});
}
}

