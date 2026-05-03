import {TitleComponent} from "shared/components/TextComponents/TitleComponent";
import {DrawComponent} from "shared/components/DrawComponents";
import {IDraw} from "shared/types";
import styles from "./LastDrawComponent.module.css";
import {TextComponent} from "shared/components";

export interface LastDrawComponentProps {
	Draw: IDraw
	className?: string
}

function LastDrawComponent(props: LastDrawComponentProps) {
	const className = props.className ? `${styles.lastDraw} ${props.className}` : styles.lastDraw;
	const areDraws = !!props.Draw;

	return (
		<div className={className}>
			<TitleComponent>Last Draw</TitleComponent>
			{areDraws && <DrawComponent Draw={props.Draw}/>}
			{!areDraws && <TextComponent>No draw found</TextComponent>}
			{/*TODO:: autres informations sur le dernier tirage*/}
		</div>
	)
}

export default LastDrawComponent;



