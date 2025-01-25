import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobApplication } from '../../Interfaces/JobApplication';
import { JobsServiceService } from '../../services/jobs-service.service';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-apply-for-job',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './apply-for-job.component.html',
  styleUrl: './apply-for-job.component.css'
})
export class ApplyForJobComponent implements OnInit {
  application: JobApplication = { applicantName: '', applicantEmail: '', cv: "", clientFileName:'', dbFilename:'', positionID:0};
  isSuccess:boolean = false;
  isAllert:boolean = false;
  message:string="";
constructor(private activatedRoute: ActivatedRoute, private jobService: JobsServiceService) {
  
}
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => { const jobId = +params['id']; 
        this.application.positionID = jobId;
      })
  }

  uploadFile(event: any): void {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
        this.application.cv = reader.result?.toString().split(',')[1];
        this.application.clientFileName = event.target.files[0].name;
    };
  }

  submitApplication(): void {
    this.jobService.submitApplication(this.application).subscribe(response => {
        this.isSuccess = response.success;
        this.isAllert = true;
        this.message = response.message;
        setTimeout(() => {
          this.isAllert = false;
        }, 5000);
    });
    
  }
}


