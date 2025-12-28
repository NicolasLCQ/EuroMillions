import {ReactNode} from "react";
import "./TextComponent.css";

interface ITitleComponentProps {
	className?: string;
	children?: ReactNode | string;
}

export default function TitleComponent(props: ITitleComponentProps) {
	return (
		<div className={props.className ?? "Text"}>{props.children}</div>
	)
}