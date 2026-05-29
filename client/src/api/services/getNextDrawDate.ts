import {API_ROUTES, euroMillionsFetch} from '../clients';

export interface IGetNextDrawDateResponse {
  nextDrawDate: Date;
}

export const getNextDrawDate = async (): Promise<IGetNextDrawDateResponse | null> => {
  const httpResponse = await euroMillionsFetch(API_ROUTES.nextDrawDate, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetNextDrawDate failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetNextDrawDateResponse;
};
