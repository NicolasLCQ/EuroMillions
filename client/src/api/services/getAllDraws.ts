import {API_ROUTES, euroMillionsFetch} from '../clients';

export interface IGetAllDrawsResponse<TDraw = unknown> {
  draws: TDraw[];
}

export const getAllDraws = async <TDraw = unknown>(): Promise<IGetAllDrawsResponse<TDraw>> => {
  const httpResponse = await euroMillionsFetch(API_ROUTES.allDraws, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetAllDraws failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetAllDrawsResponse<TDraw>;
};
