import {useQuery} from '@tanstack/react-query';
import {getNextDrawDate} from './getNextDrawDate';
import {apiQueryKeys} from './queryKeys';

export const useNextDrawDateQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.nextDrawDate,
    queryFn: getNextDrawDate,
  });
