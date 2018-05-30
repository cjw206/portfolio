import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  constructor(private http: HttpClient, private modal: AboutModal) {}

  ngOnInit(): void {
      this.http.get<Project[]>('http://localhost:5000/api/project/getall/').subscribe(data => this.projects = data);
   }
}
