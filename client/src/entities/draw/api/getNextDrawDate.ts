import {euroMillionsFetch} from '@/shared/api/euro-millions';
import type {IGetNextDrawDateResponse} from '../model/IGetNextDrawDateResponse';
import {drawApiRoutes} from './routes';

export const getNextDrawDate = async (): Promise<IGetNextDrawDateResponse | null> => {
  const httpResponse = await euroMillionsFetch(drawApiRoutes.nextDate, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetNextDrawDate failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetNextDrawDateResponse;
};
