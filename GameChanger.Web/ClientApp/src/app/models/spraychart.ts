import { Offense } from './teamStat';

export interface PlayerSprayRoot {
  sprayChart: SprayChart[]
  offenseInfo: Offense
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

export interface SprayChart {
  id: string
  code: string
  createdAt: number
  attributes: Attributes
  compactorAttributes: CompactorAttributes
}

export interface Attributes {
  playType: string
  defenders: Defender[]
  playResult: string
  hrLocation?: string
  playFlavor?: string
}

export interface Defender {
  error: boolean
  location: Location
  position: string
}

export interface Location {
  x: number
  y: number
}

export interface CompactorAttributes {
  stream: string
}

export interface Bats {
  player_id: string
  batting_side?: string
  throwing_hand?: string
  meta_seq: string
  created_at: string
  updated_at: string
}
