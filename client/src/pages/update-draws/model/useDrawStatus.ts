import {useAreUpToDateQuery} from '@/shared/api';

export function useDrawStatus() {
  const {data, isError, isLoading} = useAreUpToDateQuery();

  return {areUpToDate: data?.areUpToDate, isError, isLoading};
}
