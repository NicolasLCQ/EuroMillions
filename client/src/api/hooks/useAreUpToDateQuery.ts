import {useQuery} from '@tanstack/react-query';
import {getAreUpToDate} from '../services';
import {apiQueryKeys} from './queryKeys';

export const useAreUpToDateQuery = () =>
  useQuery({
    queryKey: apiQueryKeys.areUpToDate,
    queryFn: getAreUpToDate,
  });
