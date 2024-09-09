import DropZoneComponent from "../../../Components/DropZoneComponents/DropZoneComponent.tsx";
import {useContext} from "react";
import UploadPageContext from "../UploadPageContext/UploadPageContext.tsx";

export interface DropZoneContainerProps {
	className?: string
}

export default function DropZoneContainer(props: DropZoneContainerProps) {
	const {files, addFiles, removeFile} = useContext(UploadPageContext)

	return (
		<div className={props.className ?? "DropZoneContainer"}>
			<DropZoneComponent classname="DropZoneComponent" files={files} handleAdd={addFiles}
			                   handleDelete={removeFile}/>
		</div>
	)
}