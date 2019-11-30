import { Component } from '@angular/core';
import { WarehouseService } from '../../services/warehouse.service';
import { MatDialog } from '@angular/material/dialog';
import { AddWarehouseComponent } from '../add.warehouse/add.warehouse.component';
import { of } from 'rxjs';

@Component({
  selector: 'warehouse-home-component',
  templateUrl: './warehouse.home.component.html',
  styleUrls: ['./warehouse.home.component.scss']
})
export class WarehouseHomeComponent{
  warehoues: any[];
  title = 'Warehouse zones';
  constructor(private warehouseService: WarehouseService,
    public dialog: MatDialog){

  }

  ngOnInit(): void {
    this.getWarehouses();
  }

  getWarehouses(){
    this.warehouseService.getWarehouses().subscribe((res: any[]) => {
      this.warehoues = res;
    })
  }

  addZone(){
    let dialogRef = this.dialog.open(AddWarehouseComponent);

    dialogRef.afterClosed().subscribe(() =>{
      this.getWarehouses();
    })
  }

  toggleCategories(warehouse: any){
    if(!warehouse.Expand){
      warehouse.Expand = true;
    }else{
      warehouse.Expand = false;
    }
  }
}
