import {euroMillionsFetch} from '@/shared/api/euro-millions';

const UPLOAD_FILES_ROUTE = '/draws/upload';

export const postFiles = async (files: File[]): Promise<unknown> => {
  const body = new FormData();
  files.forEach((f) => {
    body.append('file', f);
  });

  const httpResponse = await euroMillionsFetch(UPLOAD_FILES_ROUTE, {
    method: 'POST',
    body,
  });

  if (!httpResponse.ok) {
    throw new Error(`PostFiles failed with status ${httpResponse.status}`);
  }

  return await httpResponse.json();
};
