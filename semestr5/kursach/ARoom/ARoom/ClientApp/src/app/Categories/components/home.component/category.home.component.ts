import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { MatDialog } from '@angular/material/dialog';
import { AddEditCatComponent } from '../add.edit.component/add.category.component';

@Component({
  selector: 'category-home-component',
  templateUrl: './category.home.component.html',
  styleUrls: ['./category.home.component.scss']
})
export class CategoryHomeComponent implements OnInit {
  categories: any[] = [];
  displayedColumns: string[] = ['name', 'zone', 'goodsCount', 'actions2', 'actions1'];
  title = 'ClientApp';

  constructor(private categoryService: CategoryService,
    public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(){
    this.categoryService.getCategories().subscribe((res: any[]) => {
      this.categories = res;
    })
  }

  addCategory(){
    let dialog = this.dialog.open(AddEditCatComponent);

    dialog.afterClosed().subscribe(() => {
      this.getCategories();
    })
  }

  updateCategory(cat: any){
    let dialog = this.dialog.open(AddEditCatComponent, {data: cat});

    dialog.afterClosed().subscribe(() => {
      this.getCategories();
    })
  }

  deleteCategory(cat: any){
    this.categoryService.deleteCategory(cat).subscribe(() => {
      this.getCategories();
    });
  }
}
