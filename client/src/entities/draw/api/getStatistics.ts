import {euroMillionsFetch} from '@/shared/api/euro-millions';
import type {IGetStatisticsResponse} from '../model/IGetStatisticsResponse';
import {drawApiRoutes} from './routes';

export const getStatistics = async (): Promise<IGetStatisticsResponse> => {
  const httpResponse = await euroMillionsFetch(drawApiRoutes.statistics, {
    method: 'GET',
  });

  if (!httpResponse.ok) {
    throw new Error(`GetStatistics failed with status ${httpResponse.status}`);
  }

  return (await httpResponse.json()) as IGetStatisticsResponse;
};
