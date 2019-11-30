import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { WarehouseService } from '../../services/warehouse.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'add-warehouse-component',
    templateUrl: './add.warehouse.component.html'
})
export class AddWarehouseComponent implements OnInit, OnDestroy{
    warehouse: any = {};

    constructor(private warehouseService: WarehouseService,
        public dialogRef: MatDialogRef<AddWarehouseComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {

    }

    ngOnInit(): void {
    }

    ngOnDestroy(): void {
        this.warehouse = {};
    }

    addZone() {
        this.warehouseService.addWarehouse(this.warehouse)
        .subscribe(() => {
            this.dialogRef.close();
        });
    }

    onNoClick(){
        this.dialogRef.close();
    }
}
