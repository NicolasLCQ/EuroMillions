import {useQuery} from '@tanstack/react-query';
import {getAreUpToDate} from './getAreUpToDate';
import {drawFreshnessQueryKey} from './drawFreshness';

export const useAreUpToDateQuery = () =>
  useQuery({
    queryKey: drawFreshnessQueryKey,
    queryFn: getAreUpToDate,
  });
