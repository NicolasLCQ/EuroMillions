import {useQuery} from '@tanstack/react-query';
import {getNextDrawEstimatedJackpot} from '../endpoints/getNextDrawEstimatedJackpot';

export const useNextDrawEstimatedJackpotQuery = () =>
  useQuery({
    queryKey: ['nextDrawEstimatedJackpot'],
    queryFn: getNextDrawEstimatedJackpot,
  });
