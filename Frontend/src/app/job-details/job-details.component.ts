import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { JobsServiceService } from '../../services/jobs-service.service';
import { Job } from '../../Interfaces/job';


@Component({
  selector: 'app-job-details',
  standalone: true,
  imports:[NgIf],
  templateUrl: './job-details.component.html',
  styleUrl: './job-details.component.css'
})

export class JobDetailsComponent implements OnInit {

  job: Job | null = null;
  jobId: number = 0;
  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private jobService: JobsServiceService
  ) { }

  ngOnInit(): void { 
    
    this.activatedRoute.params.subscribe(params => { 
      this.jobId = +params['id']; 
    }); 

    this.jobService
        .getJobById(this.jobId)
        .subscribe(response => { this.job = response.data; });
  }

  Apply(jobID:number) {
    this.route.navigate(['/apply/'+jobID]);
  }

  ShowAll() {
    this.route.navigate(['/']);
  }
}
