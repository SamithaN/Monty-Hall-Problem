import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  gameHistory: any[] = [];
  user: any;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    const userString = localStorage.getItem('user');
    if (userString) {
      this.user = JSON.parse(userString);
      this.gameService.getGameHistory(this.user.id).subscribe(history => {
        this.gameHistory = history;
      });
    }
  }

}
