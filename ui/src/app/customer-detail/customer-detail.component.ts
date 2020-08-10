import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {
  private customerId: number;

  constructor(activatedRoute: ActivatedRoute, private customerService: CustomerService) {
    this.customerId = +activatedRoute.snapshot.params.id;
   }

  public customer: CustomerModel;

  ngOnInit() {
    if (this.customerId) {
      this.customerService.getCustomer(this.customerId).subscribe(customer => this.customer = customer);
    }
  }

}
