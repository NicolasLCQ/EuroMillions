import {useQuery} from '@tanstack/react-query';
import {getAllDraws} from '../endpoints/getAllDraws';

export const useAllDrawsQuery = () =>
  useQuery({
    queryKey: ['allDraws'],
    queryFn: getAllDraws,
  });
