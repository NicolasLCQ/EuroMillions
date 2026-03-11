import BaseDropZoneComponent from "../../../Components/DropZoneComponents/DropZoneComponent.tsx";
import {useFiles} from "Pages/UploadPage/Hooks/useFiles.ts";
import ButtonComponents from "../../../Components/ButtonComponents/DefaultButtonComponent.tsx";
import {postFiles} from "Pages/UploadPage/Features/Files/PostFiles.ts";
import {useMutation} from "@tanstack/react-query";

export interface DropZoneComponentProps {
	className?: string
}

function DropZoneComponent(props: DropZoneComponentProps) {
	const {files, addFiles, removeFile, clearFiles} = useFiles();

	const fileMutation = useMutation({
		mutationFn: (f: File[]) => postFiles(f),
		onSuccess: clearFiles,
		onError: e => console.log(e)
	});

	const handleClick = () => fileMutation.mutate(files);

	return (
		//ajouter un element general pour afficher des erreurs comme : vous ne pouvez pas entrer 2 fois le meme fichier
		<div className={props.className}>
			<BaseDropZoneComponent files={files} handleAdd={addFiles}
			                   handleDelete={removeFile}/>
			<ButtonComponents onClick={handleClick}>Submit</ButtonComponents>
		</div>
	)
}

export default DropZoneComponent;

