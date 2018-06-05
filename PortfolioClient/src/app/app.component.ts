import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Project } from './models/project';
import { AboutModal } from './modals/app.aboutmodal';
import { AboutModalContent } from './modals/app.aboutmodalcontent';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'app';
  projects: any[];
  apiUrl = environment.apiRootUrl;

  constructor(private http: HttpClient, private modal: AboutModal) {}

  ngOnInit(): void {
      this.http.get<Project[]>(this.apiUrl+'project/getall/').subscribe(data => this.projects = data);
   }
}
