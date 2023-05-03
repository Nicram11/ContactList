
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  public isLogged: boolean = false;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fetchDataComponent: FetchDataComponent) { }

  logged(value: boolean) {
    this.isLogged = value;

  }
}

