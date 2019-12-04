import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CoreModule } from '../core/core.module';
import { CategoryHomeComponent } from './components/home.component/category.home.component';
import { AddEditCatComponent } from './components/add.edit.component/add.category.component';
import { AddWarehouseComponent } from '../WarehouseZone/components/add.warehouse/add.warehouse.component';


const routes: Routes = [
    {path : '', component : CategoryHomeComponent}
  ];
  
// @NgModule decorator with its metadata
@NgModule({
    declarations: [
        CategoryHomeComponent,
        AddEditCatComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule.forChild(routes)
    ],
    entryComponents: [AddEditCatComponent],
    providers: [],
    exports: [RouterModule]
})

export class CategoriesModule { }