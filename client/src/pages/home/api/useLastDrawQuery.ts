import {useQuery} from '@tanstack/react-query';
import {getLastDraw} from './getLastDraw';

export const useLastDrawQuery = () =>
  useQuery({
    queryKey: ['lastDraw'],
    queryFn: getLastDraw,
  });
