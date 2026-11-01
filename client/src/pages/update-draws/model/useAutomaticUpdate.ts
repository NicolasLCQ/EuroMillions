import {useQueryClient} from '@tanstack/react-query';
import {drawFreshnessQueryKey} from '@/shared/api';
import {useNotification} from '@/shared/ui/notification';
import {useUpdateAutomaticallyMutation} from '../api/hooks/useUpdateAutomaticallyMutation';

export function useAutomaticUpdate() {
  const queryClient = useQueryClient();
  const {showSuccess, showError} = useNotification();
  const mutation = useUpdateAutomaticallyMutation({
    onSuccess: async () => {
      showSuccess('Automatic update successful.');
      await queryClient.invalidateQueries({queryKey: drawFreshnessQueryKey});
    },
    onError: (error) => showError(error.message),
  });

  return {updateAutomatically: () => mutation.mutate()};
}
