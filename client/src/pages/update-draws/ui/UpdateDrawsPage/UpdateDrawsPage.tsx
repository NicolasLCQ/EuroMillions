import {useDrawStatus} from '../../model/useDrawStatus';
import {useFileUpload} from '../../model/useFileUpload';
import {useAutomaticUpdate} from '../../model/useAutomaticUpdate';
import UploadFileComponent from './UploadFile/UploadFileComponent';
import {ButtonComponents} from '@/shared/ui/button';
import {PageTitleComponent} from '@/shared/ui/page-title';
import {TextComponent} from '@/shared/ui/text';
import {TitleComponent} from '@/shared/ui/title';
import DrawStatusBannerComponent from './DrawStatusBanner/DrawStatusBannerComponent';
import styles from './UpdateDrawsPage.module.css';

function UpdateDrawsPage() {
  const drawStatus = useDrawStatus();
  const fileUpload = useFileUpload();
  const {updateAutomatically} = useAutomaticUpdate();

  return (
    <div className={styles.uploadPage}>
      <DrawStatusBannerComponent {...drawStatus} />
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
      <UploadFileComponent
        className={styles.dropZone}
        files={fileUpload.files}
        handleAdd={fileUpload.addFiles}
        handleDelete={fileUpload.removeFile}
        validateFile={fileUpload.validateFile}
        handleSubmitFiles={fileUpload.submitFiles}
      />
      <TitleComponent>Try update automatically</TitleComponent>
      <ButtonComponents onClick={updateAutomatically}>Update Automatically</ButtonComponents>
    </div>
  );
}

export default UpdateDrawsPage;
