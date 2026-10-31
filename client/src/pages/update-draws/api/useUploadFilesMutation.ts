import {useMutation, type UseMutationOptions} from '@tanstack/react-query';
import {postFiles} from './postFiles';

export const useUploadFilesMutation = (options?: UseMutationOptions<unknown, Error, File[]>) =>
  useMutation({
    mutationFn: postFiles,
    ...options,
  });
