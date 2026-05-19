export interface IFdjMoneyAmount {
  value: number;
  currency: string;
  scale: number;
}

export interface IFdjDrawInfo {
  id: string;
  external_id: string;
  cycle_number: string;
  game_external_id: string;
  game_version: number;
  cdc: number;
  wagering_ends_at: string;
  planned_at: string;
  status: string;
  forcloses_at: string;
  estimated_jackpot: IFdjMoneyAmount[];
  type: string;
  is_current: boolean;
}

export type IGetFdjDrawsResponse = IFdjDrawInfo[];
