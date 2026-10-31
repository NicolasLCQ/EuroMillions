import {useQuery} from '@tanstack/react-query';
import {getStatistics} from './getStatistics';

export const useStatisticsQuery = () =>
  useQuery({
    queryKey: ['statistics'],
    queryFn: getStatistics,
  });
