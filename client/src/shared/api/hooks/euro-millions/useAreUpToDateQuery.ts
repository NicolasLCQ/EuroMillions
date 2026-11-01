import {useQuery} from '@tanstack/react-query';
import {getAreUpToDate} from '../../endpoints/euro-millions/getAreUpToDate';
import {drawFreshnessQueryKey} from '../../endpoints/euro-millions/drawFreshness';

export const useAreUpToDateQuery = () =>
  useQuery({
    queryKey: drawFreshnessQueryKey,
    queryFn: getAreUpToDate,
  });
