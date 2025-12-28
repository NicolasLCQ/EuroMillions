import {TiTrash} from "react-icons/ti";

export interface DeleteButtonGlyphIconComponentProps {
	className?: string,
	handleDelete?: () => void
}

export default function DeleteButtonGlyphIconComponent(props: DeleteButtonGlyphIconComponentProps) {
	return (
		<button className={props.className ?? "DeleteButton"} onClick={props.handleDelete}>
			<TiTrash/>
		</button>
	)
}