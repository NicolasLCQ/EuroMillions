import {useQuery} from '@tanstack/react-query';
import {getAllDraws, type IGetAllDrawsResponse} from '../services';
import {apiQueryKeys} from './queryKeys';

export const useAllDrawsQuery = <TDraw = unknown>() =>
  useQuery<IGetAllDrawsResponse<TDraw>>({
    queryKey: apiQueryKeys.allDraws,
    queryFn: () => getAllDraws<TDraw>(),
  });
