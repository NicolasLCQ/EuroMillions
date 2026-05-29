import {fdjFetch} from '../clients';

const EURO_MILLIONS_GAME_NAME = 'euromillions';
const EURO_CURRENCY = 'EUR';

interface IFdjMoneyAmount {
  value: number;
  currency: string;
  scale: number;
}

interface IFdjDrawInfo {
  estimated_jackpot: IFdjMoneyAmount[];
  is_current: boolean;
}

type IGetFdjDrawsResponse = IFdjDrawInfo[];

export const getNextDrawEstimatedJackpot = async <TMoneyAmount = IFdjMoneyAmount>(): Promise<TMoneyAmount | null> => {
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

  const jackpot = drawInfos
    .find((drawInfo) => drawInfo.is_current)
    ?.estimated_jackpot.find((estimatedJackpot) => estimatedJackpot.currency === EURO_CURRENCY);

  return jackpot ? (jackpot as unknown as TMoneyAmount) : null;
};
