export interface Player {
  id: string
  first_name: string
  last_name: string
  number: string
  status: string
  team_id: string
  user_id: any
  meta_seq: number
  created_at: string
  updated_at: string
  bats: Bats
  person_id: string
}

export interface Bats {
  player_id: string
  batting_side: string
  throwing_hand: string
  meta_seq: string
  created_at: string
  updated_at: string
}
