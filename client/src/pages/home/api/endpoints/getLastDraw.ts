import {euroMillionsFetch} from '@/shared/api';
import type {IDraw} from '@/shared/api';

export const getLastDraw = async (): Promise<IDraw | null> => {
  const httpResponse = await euroMillionsFetch('/draws/lastdraw', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IDraw;
};
