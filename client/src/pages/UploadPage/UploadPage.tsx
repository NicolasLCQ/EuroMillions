import {apiQueryKeys, useAreUpToDateQuery, useUpdateAutomaticallyMutation, useUploadFilesMutation} from 'api/hooks';
import {useNotification} from 'app/providers';
import {useQueryClient} from '@tanstack/react-query';
import {ButtonComponents, PageTitleComponent, TextComponent, TitleComponent} from 'shared/components';
import {DrawStatusBannerComponent} from './DrawStatusBanner';
import {DropZoneComponent} from './UploadFileComponent';
import styles from './UploadPage.module.css';

function UploadPage() {
  const {showSuccess, showError} = useNotification();
  const queryClient = useQueryClient();

  const getAreUpToDateQueryResult = useAreUpToDateQuery();

  const refreshAreUpToDateStatus = async () => {
    await queryClient.invalidateQueries({queryKey: apiQueryKeys.areUpToDate});
  };

  const uploadFilesMutation = useUploadFilesMutation({
    onSuccess: async () => {
      showSuccess('Files uploaded successfully.');
      await refreshAreUpToDateStatus();
    },
    onError: (error) => showError(error.message),
  });

  const updateAutomaticallyMutation = useUpdateAutomaticallyMutation({
    onSuccess: async () => {
      showSuccess('Automatic update successful.');
      await refreshAreUpToDateStatus();
    },
    onError: (error) => showError(error.message),
  });

  const submitFiles = async (files: File[]) => {
    await uploadFilesMutation.mutateAsync(files);
  };

  const updateAutomatically = () => updateAutomaticallyMutation.mutate();

  return (
    <div className={styles.uploadPage}>
      <DrawStatusBannerComponent
        areUpToDate={getAreUpToDateQueryResult.data?.areUpToDate}
        isError={getAreUpToDateQueryResult.isError}
        isLoading={getAreUpToDateQueryResult.isLoading}
      />
      <PageTitleComponent>Upload Page</PageTitleComponent>
      <TitleComponent>You can upload the files from FDJ EuroMillions on this page</TitleComponent>
      <TextComponent className={styles.informations}>
        1 - Download Files from{' '}
        <a className={styles.euroMillionsLink} href='https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique'>
          FDJ EuroMillions History
        </a>
        <br />
        2 - Upload them below
        <br />
        3 - Submit
        <br />
        <br />
      </TextComponent>
      <DropZoneComponent className={styles.dropZone} handleSubmitFiles={submitFiles} />
      <TitleComponent>Try update automatically</TitleComponent>
      <ButtonComponents onClick={updateAutomatically}>Update Automatically</ButtonComponents>
    </div>
  );
}

export default UploadPage;
