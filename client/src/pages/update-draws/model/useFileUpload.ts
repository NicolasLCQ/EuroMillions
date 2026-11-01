import {useQueryClient} from '@tanstack/react-query';
import {drawFreshnessQueryKey} from '@/shared/api';
import {useNotification} from '@/shared/ui/notification';
import type {DropZoneComponentsProps} from '@/shared/ui/drop-zone';
import {useUploadFilesMutation} from '../api/hooks/useUploadFilesMutation';
import {useFiles} from './useFiles';

export function useFileUpload() {
  const {files, addFiles, removeFile, clearFiles} = useFiles();
  const queryClient = useQueryClient();
  const {showSuccess, showError} = useNotification();
  const mutation = useUploadFilesMutation({
    onSuccess: async () => {
      showSuccess('Files uploaded successfully.');
      await queryClient.invalidateQueries({queryKey: drawFreshnessQueryKey});
    },
    onError: (error) => showError(error.message),
  });

  const validateFile: DropZoneComponentsProps['validateFile'] = (file) => {
    if (files.some((existingFile) => existingFile.name === file.name)) {
      return {code: 'file-already-added', message: `${file.name}: already added`};
    }

    return null;
  };

  const submitFiles = async () => {
    await mutation.mutateAsync(files);
    clearFiles();
  };

  return {files, addFiles, removeFile, validateFile, submitFiles};
}
