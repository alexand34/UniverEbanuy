import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GoodsService } from '../../services/goods.service';

@Component({
    selector: 'add-edit-goods-component',
    templateUrl: './add.edit.goods.component.html'
})
export class AddEditGoodComponent implements OnInit, OnDestroy{
    good: any;
    categories: any[];
    constructor(private goodService: GoodsService,
        public dialogRef: MatDialogRef<AddEditGoodComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {
            
    }

    ngOnInit(): void {
        if(this.data.good){
            this.good = JSON.parse(JSON.stringify(this.data.good));
        }else{
            this.good = {};
        }
        this.categories = this.data.categories;
    }

    ngOnDestroy(): void {
        this.good = {};
    }

    addEditGood() {
        if(this.good.itemUniqueId && this.good.itemUniqueId != ""){
            this.goodService.updateGood(this.good).then(() => {
                this.dialogRef.close();
            });
           
        }else{
            this.goodService.addGood(this.good).then(() => {
                this.dialogRef.close();
            });
        }
    }

    onNoClick(){
        this.dialogRef.close();
    }
}
