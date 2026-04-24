import {ReactNode} from "react";
import styles from "./PageTitleComponent.module.css";

interface IPageTitleComponentProps {
	className?: string;
	children?: ReactNode | string;
}

export default function PageTitleComponent(props: IPageTitleComponentProps) {
	const className = props.className ? `${styles.pageTitle} ${props.className}` : styles.pageTitle;

	return (
		<div className={className}>{props.children}</div>
	)
}
