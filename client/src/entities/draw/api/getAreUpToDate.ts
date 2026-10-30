import {euroMillionsFetch} from '@/shared/api/euro-millions';
import type {IAreUpToDateResponse} from '../model/IAreUpToDateResponse';
import {drawApiRoutes} from './routes';

export const getAreUpToDate = async (): Promise<IAreUpToDateResponse | null> => {
  const httpResponse = await euroMillionsFetch(drawApiRoutes.areUpToDate, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetAreUpToDate failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IAreUpToDateResponse;
};
