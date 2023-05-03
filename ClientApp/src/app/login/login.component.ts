import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public isLogged: boolean = false;
  @Output() public loginEvent = new EventEmitter<boolean>();
  public request: LoginRequest = { userName: '', password: '' };
  public error: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login() {
    this.error = '';
    this.http.post(this.baseUrl + 'login', this.request).subscribe(result => {
      this.isLogged = true;
      this.loginEvent.emit(this.isLogged);
      console.log(result);
    }, err => {
        if (err.status === 401) {
          this.error = 'Niepoprawna nazwa użytkownika lub hasło';
        } else {
          this.error = 'Wystąpił błąd podczas logowania';
        }
      });
  }

}

interface LoginRequest {
  userName: string;
  password: string;
}
