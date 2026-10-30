import {euroMillionsFetch} from '@/shared/api/euro-millions';
import type {IDraw} from '../model/IDraw';
import {drawApiRoutes} from './routes';

export const getLastDraw = async (): Promise<IDraw | null> => {
  const httpResponse = await euroMillionsFetch(drawApiRoutes.last, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IDraw;
};
