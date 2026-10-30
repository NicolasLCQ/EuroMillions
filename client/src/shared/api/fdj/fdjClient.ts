import {config} from '@/shared/config';

const FDJ_API_BASE_URL = config.FDJ_API_URL.replace(/\/$/, '');

export async function fdjFetch(endpoint: string, init?: RequestInit): Promise<Response> {
  return fetch(`${FDJ_API_BASE_URL}${endpoint}`, init);
}
