import {ReactNode} from "react";
import "./TextComponent.css";

interface ITittleComponentProps{
	className?:string;
	children?: ReactNode | string;
}

export default function TittleComponent( props:ITittleComponentProps ) {
	return (
		<div className={props.className??"Text"}>{props.children}</div>
	)
}