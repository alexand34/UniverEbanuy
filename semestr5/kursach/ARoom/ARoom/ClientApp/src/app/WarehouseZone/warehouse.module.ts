import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { CoreModule } from '../core/core.module';
import { WarehouseHomeComponent } from './components/warehouse.home.component/warehouse.home.component';
import { AddWarehouseComponent } from './components/add.warehouse/add.warehouse.component';

const routes: Routes = [
    {path : '', component : WarehouseHomeComponent}
  ];
  
// @NgModule decorator with its metadata
@NgModule({
    declarations: [
        WarehouseHomeComponent,
        AddWarehouseComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule.forChild(routes)
    ],
    entryComponents: [AddWarehouseComponent],
    providers: [],
    exports: [RouterModule]
})

export class WarehouseModule { }