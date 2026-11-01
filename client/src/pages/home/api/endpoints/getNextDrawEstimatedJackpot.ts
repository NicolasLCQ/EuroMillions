import {euroMillionsFetch} from '@/shared/api';
import type {IGetNextDrawEstimatedJackpotResponse} from './IGetNextDrawEstimatedJackpotResponse';

export const getNextDrawEstimatedJackpot = async (): Promise<IGetNextDrawEstimatedJackpotResponse | null> => {
  const httpResponse = await euroMillionsFetch('/draws/nextdrawestimatedjackpot', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetNextDrawEstimatedJackpot failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetNextDrawEstimatedJackpotResponse | null;
};
