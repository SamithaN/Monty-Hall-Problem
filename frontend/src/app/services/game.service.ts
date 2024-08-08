import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private apiUrl = 'http://localhost:5113/api/game';

  constructor(private http: HttpClient) { }

  startGame(): Observable<any>
  {
    return this.http.get<any>(`${this.apiUrl}/start`);
  }

  chooseDoor(door: number): Observable<any>
  {
    return this.http.post<any>(`${this.apiUrl}/choose`,door);
  }

  finalizeChoice(switchDoor: boolean): Observable<any>
  {
    return this.http.post<any>(`${this.apiUrl}/finalize`,switchDoor);
  }
}
