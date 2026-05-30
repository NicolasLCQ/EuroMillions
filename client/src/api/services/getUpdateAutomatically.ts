import {API_ROUTES, euroMillionsFetch} from '../clients';

export const getUpdateAutomatically = async (): Promise<Response> => {
  const httpResponse = await euroMillionsFetch(API_ROUTES.updateAutomatically, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetUpdateAutomatically failed with status ${httpResponse.status}`);
  }

  return httpResponse;
};
