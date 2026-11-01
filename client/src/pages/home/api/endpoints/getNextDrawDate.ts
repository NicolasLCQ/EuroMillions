import {euroMillionsFetch} from '@/shared/api';
import type {IGetNextDrawDateResponse} from './IGetNextDrawDateResponse';

export const getNextDrawDate = async (): Promise<IGetNextDrawDateResponse | null> => {
  const httpResponse = await euroMillionsFetch('/draws/nextdrawdate', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetNextDrawDate failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetNextDrawDateResponse;
};
