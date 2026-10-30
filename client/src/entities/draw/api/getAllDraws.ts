import {euroMillionsFetch} from '@/shared/api/euro-millions';
import type {IGetAllDrawsResponse} from '../model/IGetAllDrawsResponse';
import {drawApiRoutes} from './routes';

export const getAllDraws = async (): Promise<IGetAllDrawsResponse> => {
  const httpResponse = await euroMillionsFetch(drawApiRoutes.all, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetAllDraws failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetAllDrawsResponse;
};
