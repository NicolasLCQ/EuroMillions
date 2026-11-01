import {useStatisticsQuery} from '../api/hooks/useStatisticsQuery';

export function useStatistics() {
  const {data, isLoading, isError} = useStatisticsQuery();
  const balls = data?.balls ?? [];
  const stars = data?.stars ?? [];

  return {balls, stars, hasStatistics: balls.length > 0 || stars.length > 0, isLoading, isError};
}
