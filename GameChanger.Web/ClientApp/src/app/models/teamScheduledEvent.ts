export interface TeamScheduledEvent {
  event: Event
  pregame_data: PregameData
}

export interface Event {
  id: string
  event_type: string
  sub_type: any[]
  status: string
  full_day: boolean
  team_id: string
  start: Start
  end: End
  arrive: Arrive
  location: Location
  timezone: any
  notes: string
  title: string
  series_id: any
}

export interface Start {
  datetime: string
}

export interface End {
  datetime: string
}

export interface Arrive {
  datetime: string
}

export interface Location {
  name: string
}

export interface PregameData {
  id: string
  game_id: string
  home_away: string
  lineup_id: any
  opponent_id: string
  opponent_name: string
  meta_seq: string
  created_at: string
  updated_at: string
  opponent: Opponent
}

export interface Opponent {
  root_team_id: string
  owning_team_id: string
  progenitor_team_id: any
  meta_seq: string
  created_at: string
  updated_at: string
  rootTeam: RootTeam
}

export interface RootTeam {
  id: string
  name: string
  team_type: string
  meta_seq: number
  created_at: string
  updated_at: string
}
