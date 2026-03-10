import styles from './UploadPage.module.css';
import TextComponent from '../../Shared/Components/TextComponents/TextComponent/TextComponent.tsx';
import DropZoneContainer from "./Containers/DropZoneContainer.tsx";
import PageTitleComponent from "../../Shared/Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import TitleComponent from "../../Shared/Components/TextComponents/TitleComponent/TitleComponent.tsx";


function UploadPage() {
	return (
		<div className={styles.uploadPage}>
			<PageTitleComponent>Upload Page</PageTitleComponent>
			<TitleComponent>You can upload the files from FDJ EuroMillions on this page</TitleComponent>
			<TextComponent className={styles.informations}>
				1 - Download Files from <a className={styles.euroMillionsLink}
				                           href="https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique">FDJ
				EuroMillions Historique</a><br/>
				2 - Upload them below<br/>
				3 - Submit<br/>
				<br/>
			</TextComponent>
			<DropZoneContainer className={styles.dropZone}/>
		</div>
	);
}

export default UploadPage
