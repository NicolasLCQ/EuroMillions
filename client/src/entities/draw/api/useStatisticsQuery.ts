import {useQuery} from '@tanstack/react-query';
import {getStatistics} from './getStatistics';
import {apiQueryKeys} from './queryKeys';

export const useStatisticsQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.statistics,
    queryFn: getStatistics,
  });
