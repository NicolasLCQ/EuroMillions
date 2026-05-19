import {fdjFetch} from './client';
import {IFdjMoneyAmount, IGetFdjDrawsResponse} from 'shared/types';

const EURO_MILLIONS_GAME_NAME = 'euromillions';
const EURO_CURRENCY = 'EUR';

export const getNextDrawEstimatedJackpot = async (): Promise<IFdjMoneyAmount | null> => {
  const searchParams = new URLSearchParams({
    game_name: EURO_MILLIONS_GAME_NAME,
    current: 'true',
  });

  const httpResponse = await fdjFetch(`/draws?${searchParams.toString()}`, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetNextDrawEstimatedJackpot failed with status ${httpResponse.status}`);
  }

  const drawInfos = (await httpResponse.json()) as IGetFdjDrawsResponse;

  return (
    drawInfos.find((drawInfo) => drawInfo.is_current)?.estimated_jackpot.find((jackpot) => jackpot.currency === EURO_CURRENCY) ??
    null
  );
};
