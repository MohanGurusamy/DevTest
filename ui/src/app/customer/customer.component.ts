import { Component, OnInit } from '@angular/core';
import { CustomerTypeService } from '../services/customer-type.service';
import { CustomerTypeModel } from '../models/customer-type.model';
import { CustomerModel } from '../models/customer.model';
import { tap, switchMap } from 'rxjs/operators';
import { CustomerService } from '../services/customer.service';
import { CustomerBaseModel } from '../models/customer-base.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  constructor(private customerTypeService: CustomerTypeService, private customerService: CustomerService) { }

  public allTypes: CustomerTypeModel[];
  public allCustomers: CustomerModel[];
  public newCustomerName: string;
  public newCustomerType: string;

  public ngOnInit() {
    this.customerTypeService.getAllCustomerTypes()
      .pipe(
        tap(allTypes => this.allTypes = allTypes),
        switchMap(() => this.customerService.getAllCustomers()),
      )
      .subscribe(allCustomers => this.allCustomers = allCustomers);
  }

  public createCustomer(form: NgForm) {
    if (form.invalid) {
      alert('Customer data is not valid');
      return;
    }

    this.customerService.addCustomer({
      customerTypeId: +this.newCustomerType,
      name: this.newCustomerName
    })
      .subscribe(newCustomer => {
        this.allCustomers.push(newCustomer);
      });
  }

}
