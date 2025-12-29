import {ReactNode} from "react";
import "./PageTitleComponent.css";

interface IPageTitleComponentProps {
	className?: string;
	children?: ReactNode | string;
}

export default function PageTitleComponent(props: IPageTitleComponentProps) {
	return (
		<div className={props.className ?? "PageTitleComponent"}>{props.children}</div>
	)
}