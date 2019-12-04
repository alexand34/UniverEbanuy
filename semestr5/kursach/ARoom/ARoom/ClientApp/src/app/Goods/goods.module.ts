import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { GoodsComponent } from './components/goods.component/goods.component';
import { CoreModule } from '../core/core.module';
import { AddEditGoodComponent } from './components/add.edit.goods.component/add.edit.goods.component';
const routes: Routes = [
    {path : '', component : GoodsComponent}
  ];
  
// @NgModule decorator with its metadata
@NgModule({
    declarations: [
        GoodsComponent,
        AddEditGoodComponent
    ],
    entryComponents: [AddEditGoodComponent],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule.forChild(routes)
    ],
    providers: [],
    exports: [RouterModule]
})

export class GoodsModule { }