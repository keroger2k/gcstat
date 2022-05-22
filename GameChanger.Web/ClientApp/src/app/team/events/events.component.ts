import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { PostService } from '../../services/post.service';
import { TeamInfo } from '../../models/teamInfo';


@Component({
  selector: 'app-event',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {


  routeSub: Subscription = new Subscription;
  teamId: string | undefined;
  eventId: string | undefined;
  teamInfo: TeamInfo | undefined;
  avatar: string | undefined;


  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.teamId = params.teamId;
      this.eventId = params.eventId

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
