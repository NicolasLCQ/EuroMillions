import {euroMillionsFetch} from '@/shared/api';
import type {IGetStatisticsResponse} from './statisticsResponse';

export const getStatistics = async (): Promise<IGetStatisticsResponse> => {
  const httpResponse = await euroMillionsFetch('/statistics', {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetStatistics failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetStatisticsResponse;
};
