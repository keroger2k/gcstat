export type AssociationType = 'manager' | 'family' | 'player' | 'fan';

export interface TeamInfo {
  id: string;
  name: string;
  sport: string;
  city?: string | null;
  state?: string | null;
  country?: string | null;
  age_group: string;
  season_name: string;
  season_year: number;
  competition_level: string;
  team_type: string;
  settings?: {
      scorekeeping?: {
          bats?: {
              innings_per_game: number;
              // There are additional unused fields here.
          };
      };
  };
  user_team_associations?: AssociationType[];
  team_avatar_image?: string | null;
  team_player_count?: number | null; // number of active players on team
  organizations: {
      organization_id: string;
      status: string;
  }[];
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
