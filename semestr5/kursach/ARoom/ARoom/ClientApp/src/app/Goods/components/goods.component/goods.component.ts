import { Component, OnInit } from '@angular/core';
import { GoodsService } from '../../services/goods.service';
import { MatDialog } from '@angular/material/dialog';
import { AddEditGoodComponent } from '../add.edit.goods.component/add.edit.goods.component';
import { CategoryService } from 'src/app/Categories/services/category.service';

@Component({
  selector: 'goods-component',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.scss']
})
export class GoodsComponent implements OnInit{
  title = 'ClientApp';
  goods: any[] = [];
  categories: any[] = [];
  displayedColumns: string[] = ['id', 'name', 'shortCharacteristics', 'category', 'goodsCount', 'actions2', 'actions1'];
  constructor(private goodsService: GoodsService,
    private catService: CategoryService,
    private matDialog: MatDialog){

  }

  ngOnInit(): void {
    this.getGoods();
  } 

  getGoods(){
    this.goodsService.getGoods().subscribe((res: any[]) =>{
      this.goods = res;
    });

    this.catService.getCategoriesSimple().subscribe((res: any[]) => {
      this.categories = res;
    })
  }

  addEditGood(good: any){
    if(!good){
      good = {};
    }
    let dialog = this.matDialog.open(AddEditGoodComponent, {
      data: { good : good, categories : this.categories } , 
      width: '400px'
    });

    dialog.afterClosed().subscribe(()=>{
      this.getGoods();
    })
  }

  mapCategoryIdToName(catId: any){
    return this.categories.find(x => x.id == catId).name;
  }
}
