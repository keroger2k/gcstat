import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Team, Root } from '../models/teamStat'
import { Avatar } from '../models/avatar'
import { TeamGameData } from '../models/teamGameData'
import { TeamInfo } from '../models/teamInfo'
import { TeamScheduledEvent } from '../models/teamScheduledEvent'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class PostService {

  constructor(private http: HttpClient) { }

  searchTeams(query: string) {
    return this.http.get<Array<Team>>('/api/search?query=' + query)
  }

  teamStats(id: string) {
    return this.http.get<Root>('/api/teamstats/' + id)
  }

  teamAvatar(id: string) {
    return this.http.get<Avatar>('/api/teamavatar/' + id)
  }

  teamGameData(id: string) {
    return this.http.get<Array<TeamGameData>>('/api/teamgamedata/' + id)
  }

  teamScheduledEvent(id: string) {
    return this.http.get<Array<TeamScheduledEvent>>('/api/teamscheduledevent/' + id)
  }

  teamInfo(id: string) {
    return this.http.get<TeamInfo>('/api/team/' + id)
  }

}
