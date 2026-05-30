import {config} from 'config';

const FDJ_API_BASE_URL = config.FDJ_API_URL.replace(/\/$/, '');

async function fdjFetch(endpoint: string, init?: RequestInit): Promise<Response> {
  return await fetch(`${FDJ_API_BASE_URL}${endpoint}`, init);
}

export default fdjFetch;
