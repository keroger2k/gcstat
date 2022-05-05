export interface TeamGameData {
  event_id: string
  game_data: GameData
}

export interface GameData {
  game_id: string
  scorekeeping_config_id: any
  game_state: string
  team_score: number
  opponent_score: number
  last_time_to_score_ts: string
}
