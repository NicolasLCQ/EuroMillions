import {useQuery} from '@tanstack/react-query';
import {getLastDraw} from '../services';
import {apiQueryKeys} from './queryKeys';

export const useLastDrawQuery = <TDraw = unknown>() =>
  useQuery<TDraw | null>({
    queryKey: apiQueryKeys.lastDraw,
    queryFn: () => getLastDraw<TDraw>(),
  });
