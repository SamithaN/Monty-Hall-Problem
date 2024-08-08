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

  constructor(private gameService: GameService) {}

  ngOnInit(): void {}

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
    this.gameService.finalizeChoice(switchDoor).subscribe((state) => {
      this.gameState = state;      
    });
  }

  
}
