import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { HomeModule } from './Home/home.module';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { GoodsModule } from './Goods/goods.module';
import { CoreModule } from './core/core.module';
import { WarehouseModule } from './WarehouseZone/warehouse.module';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSidenavModule,
    HomeModule,
    RouterModule,
    BrowserAnimationsModule,
    GoodsModule,
    CoreModule,
    WarehouseModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }
