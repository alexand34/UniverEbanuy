import { NgModule } from '@angular/core';
import { HomeComponent } from './components/home.component/home.component';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { CoreModule } from '../core/core.module';


const routes: Routes = [
    {path : '', component : HomeComponent}
  ];
  
// @NgModule decorator with its metadata
@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        CommonModule,
        CoreModule,
        RouterModule.forChild(routes)
    ],
    providers: [],
    exports: [RouterModule]
})

export class HomeModule { }