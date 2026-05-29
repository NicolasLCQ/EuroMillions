import {API_ROUTES, euroMillionsFetch} from '../clients';

export const getLastDraw = async <TDraw = unknown>(): Promise<TDraw | null> => {
  const httpResponse = await euroMillionsFetch(API_ROUTES.lastDraw, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetLastDraw failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as TDraw;
};
