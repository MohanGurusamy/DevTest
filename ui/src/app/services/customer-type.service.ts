import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerTypeModel } from '../models/customer-type.model';
import { of, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})
export class CustomerTypeService {
    private allTypes: CustomerTypeModel[];

    constructor(private httpClient: HttpClient) {
    }

    public getAllCustomerTypes(): Observable<CustomerTypeModel[]> {
        if (this.allTypes) {
            return of(this.allTypes);
        }
        return this.httpClient.get<CustomerTypeModel[]>('http://localhost:63235/customertype')
            .pipe(
                tap(allTypes => this.allTypes = allTypes)
            );
    }
}
