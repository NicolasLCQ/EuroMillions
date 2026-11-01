import {useAllDrawsQuery} from '../api/hooks/useAllDrawsQuery';

export function useDraws() {
  const {data, isLoading, isError} = useAllDrawsQuery();

  return {draws: data?.draws ?? [], isLoading, isError};
}
