import styles from './UploadPage.module.css';
import {TextComponent} from "shared/components/TextComponents/TextComponent";
import {DropZoneComponent} from "pages/UploadPage/DropZone";
import {PageTitleComponent} from "shared/components/TextComponents/PageTitleComponent";
import {TitleComponent} from "shared/components/TextComponents/TitleComponent";
import {ButtonComponents} from "shared/components/ButtonComponents";
import {getUpdateAutomatically, postFiles} from "api";
import {useMutation} from "@tanstack/react-query";


function UploadPage() {
	const uploadFilesMutation = useMutation({
		mutationFn: postFiles,
		onError: e => console.log(e),
	});

	const updateAutomaticallyMutation = useMutation({
		mutationFn: getUpdateAutomatically,
		onError: e => console.log(e),
	});

	const submitFiles = async (files: File[]) => {
		await uploadFilesMutation.mutateAsync(files);
	};

	const updateAutomatically = () => updateAutomaticallyMutation.mutate();

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
			<DropZoneComponent className={styles.dropZone} handleSubmitFiles={submitFiles}/>
			<TitleComponent>Try update automatically</TitleComponent>
			<ButtonComponents onClick={updateAutomatically}>Update Aotmatically</ButtonComponents>
		</div>
	);
}

export default UploadPage


