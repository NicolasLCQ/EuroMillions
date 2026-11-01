import {useMutation, type UseMutationOptions} from '@tanstack/react-query';
import {getUpdateAutomatically} from '../endpoints/getUpdateAutomatically';

export const useUpdateAutomaticallyMutation = (options?: UseMutationOptions<Response, Error, void>) =>
  useMutation({
    mutationFn: getUpdateAutomatically,
    ...options,
  });
