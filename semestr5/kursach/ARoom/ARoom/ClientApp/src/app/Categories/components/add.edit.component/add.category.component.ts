import { Component, Inject, OnInit, OnDestroy, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoryService } from '../../services/category.service';
import { WarehouseService } from 'src/app/WarehouseZone/services/warehouse.service';

@Component({
    selector: 'add-edit-cat-component',
    templateUrl: './add.category.component.html'
})
export class AddEditCatComponent implements OnInit, OnDestroy {
    @Input() category: any = {};
    zones: any[] = [];

    constructor(private categoriesService: CategoryService,
        private warehouseService: WarehouseService,
        public dialogRef: MatDialogRef<AddEditCatComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {
        if (data) {
            this.category = JSON.parse(JSON.stringify(data));
        }
    }

    ngOnInit(): void {
        this.warehouseService.getWarehousesSimple().subscribe((res: any[]) =>{
            this.zones = res;
        })
    }

    ngOnDestroy(): void {
        this.category = {};
    }

    addEditCategory() {
        if (this.category.id != undefined) {
            this.categoriesService.updateCategory(this.category)
                .subscribe(() => {
                    this.dialogRef.close();
                });
        } else {
            this.categoriesService.addCategory(this.category)
                .subscribe(() => {
                    this.dialogRef.close();
                });
        }

    }

    onNoClick() {
        this.dialogRef.close();
    }
}
