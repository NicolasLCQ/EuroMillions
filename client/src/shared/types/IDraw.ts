import {IDrawAdditionalGames} from './IDrawAdditionalGames.ts';
import {IDrawInformations} from './IDrawInformations.ts';
import {IDrawPrizeRanks} from './IDrawPrizeRanks.ts';
import {IDrawResult} from './IDrawResult.ts';

export interface IDraw extends IDrawInformations, IDrawResult, IDrawAdditionalGames, IDrawPrizeRanks {}
