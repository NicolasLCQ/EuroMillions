import {euroMillionsFetch} from './euroMillionsClient';
import type {IAreUpToDateResponse} from './drawFreshness';

export const getAreUpToDate = async (): Promise<IAreUpToDateResponse | null> => {
  const httpResponse = await euroMillionsFetch('/draws/areuptodate', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetAreUpToDate failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IAreUpToDateResponse;
};
