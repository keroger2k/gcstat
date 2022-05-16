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
        this.teamInfo = undefined;
        this.teamInfo = results;
      })

      //{
      //  "event": {
      //    "id": "eventId",
      //      "event_type": "game",
      //        "sub_type": [],
      //          "status": "scheduled",
      //            "full_day": false,
      //              "team_id": "teamId",
      //                "start": {
      //      "datetime": "2022-06-08T22:30:00Z"
      //    },
      //    "end": {
      //      "datetime": "2022-06-09T01:30:00Z"
      //    },
      //    "arrive": {
      //      "datetime": "2022-06-08T21:45:00Z"
      //    },
      //    "location": {
      //      "name": null
      //    },
      //    "timezone": "America/Chicago",
      //      "notes": "DH Field 2 vs Ox Wood",
      //        "title": "Home Game vs. Oxwood 12u",
      //          "series_id": null
      //  },
      //  "pregame_data": {
      //    "id": "eventId",
      //      "game_id": "eventId",
      //        "home_away": "home",
      //          "lineup_id": null,
      //            "opponent_id": "3ec1f043-cf0b-4796-a2ac-f2b732eba403",
      //              "opponent_name": "Oxwood 12u",
      //                "meta_seq": "13282253",
      //                  "created_at": "2022-01-31T22:56:17.338Z",
      //                    "updated_at": "2022-05-09T00:13:50.436Z",
      //                      "opponent": {
      //      "root_team_id": "3ec1f043-cf0b-4796-a2ac-f2b732eba403",
      //        "owning_team_id": "teamId",
      //          "progenitor_team_id": "85acb789-79bf-47ca-a861-4da913c0c2f5",
      //            "meta_seq": "11532419",
      //              "created_at": "2022-05-09T00:13:49.285Z",
      //                "updated_at": "2022-05-09T00:13:49.285Z",
      //                  "rootTeam": {
      //        "id": "3ec1f043-cf0b-4796-a2ac-f2b732eba403",
      //          "name": "Oxwood 12u",
      //            "team_type": "opponent",
      //              "meta_seq": 13248448,
      //                "created_at": "2022-05-09T00:13:49.281Z",
      //                  "updated_at": "2022-05-09T00:13:49.281Z"
      //      }
      //    }
      //  }
      //}
      this.postService.teamScheduledEvent(params.teamId).subscribe(results => {
        //console.log("Team scheduled events...");
        //console.log(results);
        this.schedule = [];
        this.schedule = results.filter(e => e.event.event_type === "game");
        //console.log("Team scheduled events after filter...");
        //console.log(this.schedule);
        })

      // Returns an array of games
      //{
      //  "event_id": "d97080ec-5e10-4de3-bd8e-d429871ce140",
      //    "game_data": {
      //    "game_id": "d97080ec-5e10-4de3-bd8e-d429871ce140",
      //      "scorekeeping_config_id": null,
      //        "game_state": "Game Over",
      //          "team_score": 4,
      //            "opponent_score": 8,
      //              "last_time_to_score_ts": "2022-04-03T19:33:16.064Z"
      //  }
      //}
      this.postService.teamGameData(params.teamId).subscribe(results => {
        //console.log("Team game data...");
        //console.log(results);
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

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
