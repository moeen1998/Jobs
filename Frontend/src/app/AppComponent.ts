import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule, RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet, CommonModule, HttpClientModule, FormsModule, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'jobs';
}
