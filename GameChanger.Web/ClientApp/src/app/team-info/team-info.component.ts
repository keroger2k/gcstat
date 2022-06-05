import { Component, Input, OnInit } from '@angular/core';
import { TeamScheduledEvent } from '../models/teamScheduledEvent';
import { TeamGameData } from '../models/teamGameData';
import { PostService } from '../services/post.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeamInfo } from '../models/teamInfo';


@Component({
  selector: 'team-info',
  templateUrl: './team-info.component.html',
  styleUrls: ['./team-info.component.css']
})

export class TeamInfoComponent {

  game: TeamGameData | undefined;
  teamId: string | undefined;
  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;

  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;

      this.postService.teamInfo(params.teamId).subscribe(results => {
        this.teamInfo = undefined;
        this.teamInfo = results;
      })

    });
  }
}
