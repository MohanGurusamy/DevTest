import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';
import { BaseJobModel } from '../models/base-job.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  public engineers: string[] = [];

  public jobs: JobModel[] = [];
  public allCustomers: CustomerModel[];

  public newJob: {
    engineer?: string,
    when?: Date,
    customerId?: string
  } = {};

  constructor(
    private engineerService: EngineerService,
    private jobService: JobService,
    private customerService: CustomerService) { }

  ngOnInit() {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
    this.customerService.getAllCustomers().subscribe(customers => this.allCustomers = customers);
  }

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      const request: BaseJobModel = {
        engineer: this.newJob.engineer,
        customerId: +this.newJob.customerId,
        when: this.newJob.when
      };
      this.jobService.CreateJob(request).then(() => {
        this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }
  }

}
