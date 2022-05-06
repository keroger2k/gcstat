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

  TEAM_ENDPOINT = '/api/team/';

  constructor(private http: HttpClient) { }

  searchTeams(query: string) {
    return this.http.get<Array<Team>>('/api/search?query=' + query)
  }

  teamStats(id: string) {
    return this.http.get<Root>(this.TEAM_ENDPOINT + id + '/season-stats')
  }

  teamAvatar(id: string) {
    return this.http.get<Avatar>(this.TEAM_ENDPOINT + id + '/avatar')
  }

  teamGameData(id: string) {
    return this.http.get<Array<TeamGameData>>(this.TEAM_ENDPOINT + id + '/gamedata')
  }

  teamScheduledEvent(id: string) {
    return this.http.get<Array<TeamScheduledEvent>>(this.TEAM_ENDPOINT + id + '/schedule')
  }

  teamInfo(id: string) {
    return this.http.get<TeamInfo>(this.TEAM_ENDPOINT + id)
  }

}
