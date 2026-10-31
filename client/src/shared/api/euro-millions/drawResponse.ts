export interface IDrawResult {
  ball1: number;
  ball2: number;
  ball3: number;
  ball4: number;
  ball5: number;
  star1: number;
  star2: number;
}

export interface IDrawInformations {
  drawNumber: number;
  drawDate: string;
}

export interface IDrawAdditionalGames {
  jokerPlusNumber: string | null;
  myMillionNumber: string | null;
  exceptionalEuroMillionsDrawNumber: string | null;
}

export interface IDrawPrizeRank {
  rank: number;
  winnersFrance: number;
  winnersEurope: number;
  prize: number;
}

export interface IDrawPrizeRanks {
  euroMillionsPrizeRanks: IDrawPrizeRank[];
}

export interface IDraw extends IDrawInformations, IDrawResult, IDrawAdditionalGames, IDrawPrizeRanks {}
