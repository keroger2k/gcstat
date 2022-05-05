import { Component, Input, OnInit } from '@angular/core';
import { TeamScheduledEvent } from '../../models/teamScheduledEvent';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent {

  wins: number = 0;
  losses: number = 0;
  ties: number = 0;

  @Input() schedule: any;
  @Input() games: any;
  constructor() {  }

  getGameInfo(item: TeamScheduledEvent) {
    var game = this.games.find((c: { event_id: string; }) => c.event_id == item.event.id);
    if (game && game.game_data) {
        return game;
    }
  }
}
