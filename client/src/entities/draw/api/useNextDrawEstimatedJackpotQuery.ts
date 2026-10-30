import {useQuery} from '@tanstack/react-query';
import {getNextDrawEstimatedJackpot} from './getNextDrawEstimatedJackpot';
import {apiQueryKeys} from './queryKeys';

export const useNextDrawEstimatedJackpotQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.nextDrawEstimatedJackpot,
    queryFn: getNextDrawEstimatedJackpot,
  });
