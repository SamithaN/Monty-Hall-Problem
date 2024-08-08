import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:5113/api/auth';

  constructor(private http: HttpClient) { }

  register(user: { username: string, password: string }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }

  login(user: { username: string, password: string }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, user);
  }
}
