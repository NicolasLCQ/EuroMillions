export interface IDrawItemStatistics {
  nbTimesDraw: number;
  nbDrawsSinceLastOccurrence: number;
  averageNbDrawsBetweenOccurrences: number;
  minimumNbDrawsBetweenOccurrences: number;
  maximumNbDrawsBetweenOccurrences: number;
  varianceNbDrawsBetweenOccurrences: number;
  standardDeviationNbDrawsBetweenOccurrences: number;
}

export interface IBallStatistics extends IDrawItemStatistics {
  ball: number;
}

export interface IStarStatistics extends IDrawItemStatistics {
  star: number;
}

export interface IGetStatisticsResponse {
  balls: IBallStatistics[];
  stars: IStarStatistics[];
}
