import {euroMillionsFetch} from '@/shared/api/euro-millions';

const UPDATE_AUTOMATICALLY_ROUTE = '/draws/updateautomatically';

export const getUpdateAutomatically = async (): Promise<Response> => {
  const httpResponse = await euroMillionsFetch(UPDATE_AUTOMATICALLY_ROUTE, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetUpdateAutomatically failed with status ${httpResponse.status}`);
  }

  return httpResponse;
};
