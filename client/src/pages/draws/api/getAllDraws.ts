import {euroMillionsFetch} from '@/shared/api';
import type {IGetAllDrawsResponse} from './IGetAllDrawsResponse';

export const getAllDraws = async (): Promise<IGetAllDrawsResponse> => {
  const httpResponse = await euroMillionsFetch('/draws/all', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetAllDraws failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetAllDrawsResponse;
};
