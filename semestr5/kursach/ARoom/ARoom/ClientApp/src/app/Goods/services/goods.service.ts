import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class GoodsService {
    constructor(private http: HttpClient) {
        
    }

    getGoods(){
        return this.http.get('api/Goods/GetGoods');
    }

    addGood(good: any){
        return this.http.post('api/Goods/Add', good).toPromise();
    }

    updateGood(good: any){
        return this.http.post('api/Goods/Update', good).toPromise();
    }
}