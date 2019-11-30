import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path : 'home', loadChildren: './Home/home.module#HomeModule' },
  {path : 'goods', loadChildren: './Goods/goods.module#GoodsModule' },
  {path : 'warehouse', loadChildren: './WarehouseZone/warehouse.module#WarehouseModule' },
  {path : '', redirectTo : '/home', pathMatch : 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
