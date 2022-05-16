import { Component, Input, OnInit } from '@angular/core';
import { TeamScheduledEvent } from '../../models/teamScheduledEvent';
import { TeamGameData } from '../../models/teamGameData';


@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent {

  wins: number = 0;
  losses: number = 0;
  ties: number = 0;
  game: TeamGameData | undefined;
  teamId: string | undefined;

  @Input() schedule: any;
  @Input() games: any;
  constructor() { }

  getResult(teamScore: number, oppScore: number) {
    if (teamScore > oppScore) {
      return "W";
    } else if (teamScore < oppScore) {
      return "L";
    }
    else {
      return "T";
    }
  }

  getGameInfo(item: TeamScheduledEvent) {
    var local = this.games?.find((c: { event_id: string; }) => c.event_id == item.event.id);
    if (local?.game_data) {
      this.teamId = item.event.team_id;
      this.game = local;
      console.log(local);
      return local;
    }
  }
}
