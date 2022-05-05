import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { PostService } from '../services/post.service';
import { TeamInfo } from '../models/teamInfo';
import { TeamScheduledEvent } from '../models/teamScheduledEvent';
import { TeamGameData } from '../models/teamGameData';
import { Team, Root, Stats2 } from '../models/teamStat';


@Component({
  selector: 'app-home',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})

export class TeamComponent {

  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;
  schedule: Array<TeamScheduledEvent> | undefined;
  games: Array<TeamGameData> | undefined;
  teamId: string | undefined;
  avatar: string | undefined;
  currentTeam: Root | undefined;
  players: Array<Stats2> = [];

  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;

      this.postService.teamAvatar(params.teamId).subscribe(results => {
        this.avatar = "";
        this.avatar = results.full_media_url;
      })

      this.postService.teamInfo(params.teamId).subscribe(results => {
        this.teamInfo = results;
      })

      this.postService.teamScheduledEvent(params.teamId).subscribe(results => {
        this.schedule = results.filter(e => e.event.event_type === "game");
      })

      this.postService.teamGameData(params.teamId).subscribe(results => {
        this.games = results;
      })

      this.postService.teamStats(params.teamId).subscribe(results => {
        this.currentTeam = results;
        this.players = [];

        for (let key in results.stats_data.players) {
          let value = results.stats_data.players[key].stats;
          this.players.push(value)
        }
      })
    });
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
