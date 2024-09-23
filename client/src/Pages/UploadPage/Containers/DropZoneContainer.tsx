import DropZoneComponent from "../../../Components/DropZoneComponents/DropZoneComponent.tsx";
import {useFiles} from "../Hooks/useFiles.ts";
import ButtonComponents from "../../../Components/ButtonComponents/DefaultButtonComponent.tsx";
import {postFiles} from "../Features/Files/PostFiles.ts";

export interface DropZoneContainerProps {
	className?: string
}

export default function DropZoneContainer(props: DropZoneContainerProps) {
	const {files, addFiles, removeFile} = useFiles();

	return (
		<div className={props.className ?? "DropZoneContainer"}>
			<DropZoneComponent classname="DropZoneComponent" files={files} handleAdd={addFiles}
			                   handleDelete={removeFile}/>
			<ButtonComponents onClick={() => postFiles(files)}>Submit</ButtonComponents>
		</div>
	)
}