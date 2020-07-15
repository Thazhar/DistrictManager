import { Component } from '@angular/core';

export const baseUrl = 'https://localhost:44328/api/';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'District Manager';
}

