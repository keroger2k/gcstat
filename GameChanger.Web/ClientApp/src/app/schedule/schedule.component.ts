import { Component, Input, OnInit } from '@angular/core';
import { TeamScheduledEvent } from '../models/teamScheduledEvent';
import { TeamGameData } from '../models/teamGameData';
import { PostService } from '../services/post.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeamInfo } from '../models/teamInfo';


@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})

export class ScheduleComponent {

  game: TeamGameData | undefined;
  games: Array<TeamGameData> | undefined;
  teamId: string | undefined;
  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;
  schedule: Array<TeamScheduledEvent> | undefined;

  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;

      this.postService.teamInfo(params.teamId).subscribe(results => {
        this.teamInfo = results;
      });

      this.postService.teamScheduledEvent(params.teamId).subscribe(results => {
        this.schedule = results.filter(e => e.event.event_type === "game");
      });


      this.postService.teamGameData(params.teamId).subscribe(results => {
        this.games = results;
      });

    });
  }



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
    this.teamId = item.event.team_id;
    this.game = local;
    return local;
  }
}
