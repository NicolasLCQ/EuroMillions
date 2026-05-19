const FDJ_API_BASE_URL = 'https://www.sto.api.fdj.fr/anonymous/service-draw-info/v3';

async function fdjFetch(endpoint: string, init?: RequestInit): Promise<Response> {
  return await fetch(`${FDJ_API_BASE_URL}${endpoint}`, init);
}

export default fdjFetch;
