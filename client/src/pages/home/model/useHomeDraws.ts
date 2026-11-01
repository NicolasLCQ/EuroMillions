import {useAreUpToDateQuery} from '@/shared/api';
import {useLastDrawQuery} from '../api/hooks/useLastDrawQuery';
import {useNextDrawDateQuery} from '../api/hooks/useNextDrawDateQuery';
import {useNextDrawEstimatedJackpotQuery} from '../api/hooks/useNextDrawEstimatedJackpotQuery';

export function useHomeDraws() {
  const getLastDrawQueryResult = useLastDrawQuery();
  const getAreUpToDateQueryResult = useAreUpToDateQuery();
  const getNextDrawQueryResult = useNextDrawDateQuery();
  const getNextDrawEstimatedJackpotQueryResult = useNextDrawEstimatedJackpotQuery();

  const isLoading =
    getLastDrawQueryResult.isLoading ||
    getAreUpToDateQueryResult.isLoading ||
    getNextDrawQueryResult.isLoading ||
    getNextDrawEstimatedJackpotQueryResult.isLoading;
  const isError = getAreUpToDateQueryResult.error || getNextDrawQueryResult.error || getNextDrawEstimatedJackpotQueryResult.error;

  const areUpToDate = getAreUpToDateQueryResult.data?.areUpToDate;
  const nextDrawDate = getNextDrawQueryResult.data?.nextDrawDate;
  const estimatedJackpot = getNextDrawEstimatedJackpotQueryResult.data ?? null;

  return {
    isLoading,
    isError,
    hasData: !!getAreUpToDateQueryResult.data && !!getNextDrawQueryResult.data,
    areUpToDate,
    nextDrawDate,
    estimatedJackpot,
    lastDraw: getLastDrawQueryResult.data,
  };
}
