import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { JobsServiceService } from '../../services/jobs-service.service';
import { HttpClientModule } from '@angular/common/http';
import { Job } from '../../Interfaces/job';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-all-jobs',
  standalone:true,
  imports: [NgFor, HttpClientModule, RouterModule],
  templateUrl: './all-jobs.component.html',
  styleUrl: './all-jobs.component.css'
})
export class AllJobsComponent implements OnInit {
  jobs:Job[]=[];
  constructor(private jobService: JobsServiceService,private route: Router) {}

  ngOnInit(): void {
    this.jobService.getAllPositions().subscribe(response => {
      this.jobs = response.data;
    });
  }

  ShowDetails(ID:number) {
    this.route.navigate(['job-details/'+ID]);
  }

}
