import {TiTrash} from "react-icons/ti";

export interface DeleteButtonComponentProps {
	className?: string,
	text?: string,
	onClick?: () => void
}

export default function DeleteButtonComponent(props: DeleteButtonComponentProps) {
	return (
		<button className={props.className ?? "DeleteButton"} onClick={props.onClick}>
			<TiTrash/>
		</button>
	)
}