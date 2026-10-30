import {useQuery} from '@tanstack/react-query';
import {getLastDraw} from './getLastDraw';
import {apiQueryKeys} from './queryKeys';

export const useLastDrawQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.lastDraw,
    queryFn: getLastDraw,
  });
