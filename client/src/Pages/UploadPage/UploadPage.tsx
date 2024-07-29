import './UploadPage.css';
import DropZoneComponents from "../../Components/DropZoneComponents/DropZoneComponents.tsx";
import ButtonComponents from "../../Components/ButtonComponents/ButtonComponent.tsx";
import TittleComponent from "../../Components/TextComponents/TittleComponent/TittleComponent.tsx";
import TextComponent from '../../Components/TextComponents/TextComponent/TextComponent.tsx';


function UploadPage() {

	return (
		<div className="UploadPage">
			<TittleComponent className="Title">You can upload the files from FDJ EuroMillions on this
				page</TittleComponent>
			<TextComponent className="Informations">
				1 - Download Files from <a className="EuroMillionsLink" href="https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique">FDJ
				EuroMillions Historique</a><br/>
				2 - Upload them below<br/>
				3 - Submit<br/>
				<br/>
			</TextComponent>
			<DropZoneComponents classname="DropZone"/>
			<ButtonComponents text="submit"/>
		</div>
	);
}

export default UploadPage
