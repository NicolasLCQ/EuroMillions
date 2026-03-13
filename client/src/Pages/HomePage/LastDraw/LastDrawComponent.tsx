import TitleComponent from "shared/components/TextComponents/TitleComponent";
import DrawComponent from "shared/components/DrawComponents";
import {IDraw} from "shared/types";
import styles from "./LastDrawComponent.module.css";

export interface LastDrawComponentProps {
	Draw: IDraw
	className?: string
}

function LastDrawComponent(props: LastDrawComponentProps) {
	const className = props.className ? `${styles.lastDraw} ${props.className}` : styles.lastDraw;

	return (
		<div className={className}>
			<TitleComponent>Last Draw</TitleComponent>
			<DrawComponent Draw={props.Draw}/>
		</div>
	)
}

export default LastDrawComponent;



