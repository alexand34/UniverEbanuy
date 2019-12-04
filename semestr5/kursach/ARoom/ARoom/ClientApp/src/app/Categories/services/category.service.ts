import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    constructor(private http: HttpClient) {
        
    }

    getCategories(){
        return this.http.get('api/Category/GetCategories');
    }

    addCategory(cat: any){
        return this.http.post('api/category/AddCategory', cat);
    }
    updateCategory(cat: any){
        return this.http.post('api/category/UpdateCategory', cat)
    }
    deleteCategory(cat: any){
        return this.http.post('api/category/DeleteCategory', cat)
    }

    getCategoriesSimple(){
        return this.http.get('api/Category/GetCategoriesSimple');
    }
}