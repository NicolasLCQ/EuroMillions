import styles from './UploadPage.module.css';
import {TextComponent} from 'shared/components/TextComponents/TextComponent';
import {DropZoneComponent} from 'pages/UploadPage/UploadFileComponent';
import {PageTitleComponent} from 'shared/components/TextComponents/PageTitleComponent';
import {TitleComponent} from 'shared/components/TextComponents/TitleComponent';
import {ButtonComponents} from 'shared/components/ButtonComponents';
import {getUpdateAutomatically, postFiles} from 'api';
import {useMutation, useQuery, useQueryClient} from '@tanstack/react-query';
import {useNotification} from 'app/Providers/notification-provider';
import {API_ROUTES} from 'api/client';
import {getAreUpToDate} from 'api/getAreUpToDate.ts';
import {DrawStatusBannerComponent} from 'pages/UploadPage/DrawStatusBanner';

function UploadPage() {
  const {showSuccess, showError} = useNotification();
  const queryClient = useQueryClient();

  const getAreUpToDateQueryResult = useQuery({
    queryKey: [API_ROUTES.areUpToDate],
    queryFn: getAreUpToDate,
  });

  const refreshAreUpToDateStatus = async () => {
    await queryClient.invalidateQueries({queryKey: [API_ROUTES.areUpToDate]});
  };

  const uploadFilesMutation = useMutation({
    mutationFn: postFiles,
    onSuccess: async () => {
      showSuccess('Files uploaded successfully.');
      await refreshAreUpToDateStatus();
    },
    onError: (e) => showError(e.message),
  });

  const updateAutomaticallyMutation = useMutation({
    mutationFn: getUpdateAutomatically,
    onSuccess: async () => {
      showSuccess('Automatic update successful.');
      await refreshAreUpToDateStatus();
    },
    onError: (e) => showError(e.message),
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
