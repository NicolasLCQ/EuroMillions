import {ReactNode} from "react";
import "./TittleComponent.css";

interface ITittleComponentProps{
	className?:string;
	children?: ReactNode | string;
}

export default function TittleComponent( props:ITittleComponentProps ) {
	return (
		<div className={props.className??"Title"}>{props.children}</div>
	)
}