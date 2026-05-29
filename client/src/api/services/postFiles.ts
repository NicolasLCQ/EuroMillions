import {API_ROUTES, euroMillionsFetch} from '../clients';

export const postFiles = async (files: File[]): Promise<unknown> => {
  const body = new FormData();
  files.forEach((f) => {
    body.append('file', f);
  });

  const httpResponse = await euroMillionsFetch(API_ROUTES.uploadFiles, {
    method: 'POST',
    body: body,
  });

  if (!httpResponse.ok) {
    throw new Error(`PostFiles failed with status ${httpResponse.status}`);
  }

  return await httpResponse.json();
};
