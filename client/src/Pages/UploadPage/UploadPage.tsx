import './UploadPage.css';
import DropZoneComponents from "../../Components/DropZoneComponents/DropZoneComponents.tsx";
import ButtonComponents from "../../Components/ButtonComponents/ButtonComponent.tsx";

function UploadPage() {

	return (
		<div className="UploadPage">
			<DropZoneComponents/>
			<ButtonComponents text="submit"/>
		</div>
	);
}

export default UploadPage
