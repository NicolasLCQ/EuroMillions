import type {IDrawAdditionalGames} from './IDrawAdditionalGames';
import type {IDrawInformations} from './IDrawInformations';
import type {IDrawPrizeRanks} from './IDrawPrizeRanks';
import type {IDrawResult} from './IDrawResult';

export interface IDraw extends IDrawInformations, IDrawResult, IDrawAdditionalGames, IDrawPrizeRanks {}
