import {useQuery} from '@tanstack/react-query';
import {getNextDrawEstimatedJackpot} from './getNextDrawEstimatedJackpot';

export const useNextDrawEstimatedJackpotQuery = () =>
  useQuery({
    queryKey: ['nextDrawEstimatedJackpot'],
    queryFn: getNextDrawEstimatedJackpot,
  });
