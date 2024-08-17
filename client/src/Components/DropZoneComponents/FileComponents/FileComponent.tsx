import DeleteButtonComponent from "../../ButtonComponents/DeleteButtonComponent/DeleteButtonComponent.tsx";
import TextComponent from "../../TextComponents/TextComponent/TextComponent.tsx";

export interface FileComponentProps {
	className?: string,
	file: File,
	handleDelete?: (file: File) => void,
}

export default function FileComponent(props: FileComponentProps) {
	return (
		<div className={props.className ?? "FileComponent"}>
			{props.handleDelete &&
				<DeleteButtonComponent className="DeleteFileButton"/>}
			<TextComponent className="FileName">{props.file.name}</TextComponent>
		</div>
	)
}