import { Routes } from '@angular/router';
import { JobDetailsComponent } from './job-details/job-details.component';
import { AllJobsComponent } from './all-jobs/all-jobs.component';
import { ApplyForJobComponent } from './apply-for-job/apply-for-job.component';

export const routes: Routes = [
    { path: '', component: AllJobsComponent },
    { path: 'job-details/:id', component: JobDetailsComponent },
    { path: 'apply/:id', component: ApplyForJobComponent },
];
