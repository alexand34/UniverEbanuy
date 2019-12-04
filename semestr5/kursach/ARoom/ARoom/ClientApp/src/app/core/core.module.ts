import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
// @NgModule decorator with its metadata
@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatButtonModule,
        HttpClientModule,
        FormsModule,
        MatDialogModule,
        MatInputModule,
        MatTableModule,
        MatSelectModule
    ],
    providers: [],
    exports: [
        MatInputModule,
        CommonModule,
        MatButtonModule, 
        HttpClientModule,
        MatDialogModule,
        FormsModule,
        MatTableModule,
        MatSelectModule
    ]
})

export class CoreModule { }