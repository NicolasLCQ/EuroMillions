import React from "react";
import styles from "./BannerComponent.module.css";

export type BannerComponentState = "information" | "success" | "error";

export interface BannerComponentProps extends React.PropsWithChildren {
	className?: string;
	state?: BannerComponentState;
}

function BannerComponent(props: BannerComponentProps) {
	const state = props.state ?? "information";
	const className = props.className
		? `${styles.banner} ${styles[state]} ${props.className}`
		: `${styles.banner} ${styles[state]}`;

	return (
		<div className={className}>
			{props.children}
		</div>
	);
}

export default BannerComponent;
