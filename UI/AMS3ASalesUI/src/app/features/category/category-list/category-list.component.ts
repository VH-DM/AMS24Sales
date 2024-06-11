import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/Category';


@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})

export class CategoryListComponent implements OnInit{

  categories?: Category[]

  constructor(private categoryService: CategoryService){}

    ngOnInit(): void {
      this.categoryService.getAllCategory()
      .subscribe({
        next: (response) => {
          this.categories = response;
        }

      });
    }

}
