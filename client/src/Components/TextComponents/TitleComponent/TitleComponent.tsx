import './TitleComponent.css'

import {ReactNode} from "react";
import "./TitleComponent.css";

interface ITitleComponentProps {
	className?: string;
	children?: ReactNode | string;
}

function TitleComponent(props: ITitleComponentProps) {
	return (
		<div className={props.className ?? "TitleComponent"}>{props.children}</div>
	)
}

export default TitleComponent;