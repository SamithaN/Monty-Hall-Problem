import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  user: any;

  constructor(private router: Router, private gameService: GameService) { }

  ngOnInit(): void {
  }

  exitApplication(): void {
    window.close(); // Close the application
  }

  viewHistory(): void {
    const userString = localStorage.getItem('user');
    if (userString) {
      this.user = JSON.parse(userString);
    }
    //const user = JSON.parse(localStorage.getItem('user'));
    if (this.user) {
      this.gameService.getGameHistory(this.user.id).subscribe(records => {
        
      });
    } else {
      this.router.navigate(['/login']);
    }
  }
}
