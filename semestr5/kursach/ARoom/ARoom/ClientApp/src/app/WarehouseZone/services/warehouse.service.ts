import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class WarehouseService {
    constructor(private http: HttpClient) {
        
    }

    getWarehouses(){
        return this.http.get('api/Warehouse/getZones');
    }

    addWarehouse(warehouse: any){
        return this.http.post('api/warehouse/add', warehouse);
    }
}