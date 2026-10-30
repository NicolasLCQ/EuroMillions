import {useQuery} from '@tanstack/react-query';
import {getAllDraws} from './getAllDraws';
import {apiQueryKeys} from './queryKeys';

export const useAllDrawsQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.allDraws,
    queryFn: getAllDraws,
  });
