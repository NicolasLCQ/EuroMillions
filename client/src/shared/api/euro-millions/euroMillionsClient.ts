import {config} from '@/shared/config';

const API_BASE_URL = config.EUROMILLIONS_API_URL.replace(/\/$/, '');

export async function euroMillionsFetch(endpoint: string, init?: RequestInit): Promise<Response> {
  return fetch(`${API_BASE_URL}${endpoint}`, init);
}
