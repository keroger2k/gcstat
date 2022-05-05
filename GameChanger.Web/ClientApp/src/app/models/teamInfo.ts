export interface TeamInfo {
  id: string
  name: string
  team_type: string
  meta_seq: number
  created_at: string
  updated_at: string
  teamExternalAssociation: any
  maxPrepsSyncState: any
  organizations: any[]
  settings: Settings
  adminTeam: AdminTeam
  sport: string
  city: string
  state: string
  country: string
  age_group: string
  season_name: string
  season_year: number
  competition_level: string
  stat_access_level: string
  paid_access_level: any
  scorekeeping_access_level: string
  streaming_access_level: string
  ngb: string
  user_team_associations: any[]
  team_avatar_image: any
  team_player_count: any
}

export interface Settings {
  scorekeeping: Scorekeeping
}

export interface Scorekeeping {
  bats: Bats
}

export interface Bats {
  innings_per_game: number
  pitch_count_alert_1: any
  pitch_count_alert_2: any
  shortfielder_type: string
  meta_seq: string
  created_at: string
  updated_at: string
}

export interface AdminTeam {
  root_team_id: string
  age_group: string
  city: string
  competition_level: string
  country: string
  ngb: string
  paid_access_level: any
  rolled_over_from_team_id: any
  scorekeeping_access_level: any
  season_name: string
  season_year: number
  sport: string
  stat_access_level: any
  state: string
  streaming_access_level: string
  meta_seq: string
  created_at: string
  updated_at: string
}
