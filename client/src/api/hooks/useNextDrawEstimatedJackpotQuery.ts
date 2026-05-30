import {useQuery} from '@tanstack/react-query';
import {getNextDrawEstimatedJackpot} from '../services';
import {apiQueryKeys} from './queryKeys';

export const useNextDrawEstimatedJackpotQuery = <TMoneyAmount = unknown>() =>
  useQuery<TMoneyAmount | null>({
    queryKey: apiQueryKeys.nextDrawEstimatedJackpot,
    queryFn: () => getNextDrawEstimatedJackpot<TMoneyAmount>(),
  });
