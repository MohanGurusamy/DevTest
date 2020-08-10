import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { CustomerBaseModel } from '../models/customer-base.model';

@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    constructor(private httpClient: HttpClient) {
    }

    public getAllCustomers(): Observable<CustomerModel[]> {
        return this.httpClient.get<CustomerModel[]>('http://localhost:63235/customer');
    }

    public addCustomer(model: CustomerBaseModel): Observable<CustomerModel> {
        return this.httpClient.post<CustomerModel>('http://localhost:63235/customer', model);
    }

    public getCustomer(customerId: number) {
        return this.httpClient.get<CustomerModel>(`http://localhost:63235/customer/${customerId}`);
    }
}
