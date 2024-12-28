import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppHeaderComponent } from './components/app-header/app-header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule,AppHeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit,OnDestroy{
  title = 'Dating App';
  users:any;
 private http=inject(HttpClient);
 ngOnInit(): void {
   this.http.get('http://localhost:5233/api/Users').subscribe({
  next:(data)=>{this.users=data},
  error:()=>{},
  complete:()=>{console.log(this.users)}
  
  })
 }

 ngOnDestroy(): void {
   
 }
  constructor(private Httpclient:HttpClient){

  }
}
