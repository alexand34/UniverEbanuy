import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
// @NgModule decorator with its metadata
@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatButtonModule,
        HttpClientModule,
        FormsModule,
        MatDialogModule,
        MatInputModule
    ],
    providers: [],
    exports: [
        MatInputModule,
        CommonModule,
        MatButtonModule, 
        HttpClientModule,
        MatDialogModule,
        FormsModule
    ]
})

export class CoreModule { }