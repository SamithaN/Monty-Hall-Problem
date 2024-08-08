import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string = '';
  password: string = '';
  error: string | undefined;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login(): void {
    this.authService.login({ username: this.username, password: this.password }).subscribe(
      user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigate(['/menu']);
      },
      err => {
        this.error = 'Invalid credentials';
      }
    );
  }

  register(): void {
    this.authService.register({ username: this.username, password: this.password }).subscribe(
      user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigate(['/menu']);
      },
      err => {
        this.error = 'Registration failed';
      }
    );
  }

}
