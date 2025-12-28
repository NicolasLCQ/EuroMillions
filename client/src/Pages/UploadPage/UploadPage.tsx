import './UploadPage.css';
import TextComponent from 'Components/TextComponents/TextComponent/TextComponent.tsx';
import DropZoneContainer from "./Containers/DropZoneContainer.tsx";
import PageTitleComponent from "Components/TextComponents/PageTitleComponent/PageTitleComponent.tsx";
import TitleComponent from "Components/TextComponents/TitleComponent/TitleComponent.tsx";


function UploadPage() {
	return (
		<div className="UploadPage">
			<PageTitleComponent>Upload Page</PageTitleComponent>
			<TitleComponent>You can upload the files from FDJ EuroMillions on this page</TitleComponent>
			<TextComponent className="Informations">
				1 - Download Files from <a className="EuroMillionsLink"
				                           href="https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique">FDJ
				EuroMillions Historique</a><br/>
				2 - Upload them below<br/>
				3 - Submit<br/>
				<br/>
			</TextComponent>
			<DropZoneContainer className="DropZone"/>
		</div>
	);
}

export default UploadPage
