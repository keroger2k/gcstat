import { Component, OnInit } from '@angular/core';
import { Team } from '../models/teamStat';
import { PostService } from '../services/post.service';



@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private postService: PostService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  searchHits: Array<Team> | undefined;

  sendData(event: any) {

    let query: string = event.target.value;

    let matchSpaces: any = query.match(/\s*/);
    if (matchSpaces[0] == query) {
      this.searchHits = [];
      return
    }

    this.postService.searchTeams(query.trim()).subscribe(results => {
      this.searchHits = results;
    })
  }
}
