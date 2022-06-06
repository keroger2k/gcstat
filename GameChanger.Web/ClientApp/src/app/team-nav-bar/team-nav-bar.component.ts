import { Component, OnInit } from '@angular/core';
import { Team } from '../models/teamStat';
import { PostService } from '../services/post.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeamGameData } from '../models/teamGameData';
import { TeamInfo } from '../models/teamInfo';
import { TeamScheduledEvent } from '../models/teamScheduledEvent';

type TeamRecord = {
  wins: number | 0;
  losses: number | 0;
  ties: number | 0;
}

@Component({
  selector: 'team-nav-bar',
  templateUrl: './team-nav-bar.component.html',
  styleUrls: ['./team-nav-bar.component.scss']
})

export class TeamNavBarComponent {

  game: TeamGameData | undefined;
  games: Array<TeamGameData> | undefined;
  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;
  avatar: string | undefined;
  teamId: string | undefined;
  schedule: Array<TeamScheduledEvent> | undefined;
  record: TeamRecord | undefined;


  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;

      this.postService.teamAvatar(params.teamId).subscribe(results => {
        this.avatar = results.full_media_url;
      });

      this.postService.teamInfo(params.teamId).subscribe(results => {
        this.teamInfo = results;
      });

      this.postService.teamGameData(params.teamId).subscribe(results => {
        this.games = results;
        this.record = <TeamRecord>({
          wins: results.filter(x => x.game_data !== null).filter(x => x.game_data.team_score > x.game_data.opponent_score).length,
          losses: results.filter(x => x.game_data !== null).filter(x => x.game_data.team_score < x.game_data.opponent_score).length,
          ties: results.filter(x => x.game_data !== null).filter(x => x.game_data.team_score === x.game_data.opponent_score).length
        });
      });
    
    });
  }
}
