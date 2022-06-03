import { Component, Input, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeamInfo } from '../models/teamInfo';
import { Team, Root, Stats, Stats2 } from '../models/teamStat';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})

export class StatsComponent {


  teamId: string | undefined;
  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;
  currentTeam: Root | undefined;
  players: Array<Stats2> = [];

  @Input() schedule: any;
  @Input() games: any;
  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;


      
      this.postService.teamGameData(params.teamId).subscribe(results => {
        this.games = [];
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

}
