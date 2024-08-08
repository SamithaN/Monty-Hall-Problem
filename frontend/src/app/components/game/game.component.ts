import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
})
export class GameComponent implements OnInit {
  gameState: any;
  selectedDoor?: any;
  switchDoor?: boolean;
  user: any;

  constructor(private gameService: GameService) {}

  ngOnInit(): void {
    const userString = localStorage.getItem('user');
    if (userString) {
      this.user = JSON.parse(userString);
    }   
  }

  startGame(): void {
    this.gameService.startGame().subscribe((state) => {
      this.gameState = state;
      this.selectedDoor = null;
      this.switchDoor = false;
    });
  }

  chooseDoor(door: number): void {
    this.selectedDoor = door;
    this.gameService.chooseDoor(door).subscribe((state) => {
      this.gameState = state;
    });
  }

  finalizeChoice(switchDoor: boolean): void {
    this.switchDoor = switchDoor;
    this.gameService.finalizeChoice(this.user.id,switchDoor).subscribe((state) => {
      this.gameState = state;      
    });
  }

  
}
