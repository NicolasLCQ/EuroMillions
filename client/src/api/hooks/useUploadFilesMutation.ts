import {useMutation, type UseMutationOptions} from '@tanstack/react-query';
import {postFiles} from '../services';

export const useUploadFilesMutation = (options?: UseMutationOptions<unknown, Error, File[]>) =>
  useMutation({
    mutationFn: postFiles,
    ...options,
  });
