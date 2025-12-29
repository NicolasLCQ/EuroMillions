import {ReactNode} from "react";
import "./TextComponent.css";

interface ITextComponentProps {
	className?: string;
	children?: ReactNode | string;
}

export default function TextComponent(props: ITextComponentProps) {
	return (
		<div className={props.className ?? "TextComponent"}>{props.children}</div>
	)
}