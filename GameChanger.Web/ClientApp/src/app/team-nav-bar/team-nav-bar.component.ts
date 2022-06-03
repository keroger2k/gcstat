import { Component, OnInit } from '@angular/core';
import { Team } from '../models/teamStat';
import { PostService } from '../services/post.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeamInfo } from '../models/teamInfo';




@Component({
  selector: 'team-nav-bar',
  templateUrl: './team-nav-bar.component.html',
  styleUrls: ['./team-nav-bar.component.css']
})

export class TeamNavBarComponent {

  routeSub: Subscription = new Subscription;
  teamInfo: TeamInfo | undefined;
  avatar: string | undefined;
  teamId: string | undefined;

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
    
    });
  }
}
