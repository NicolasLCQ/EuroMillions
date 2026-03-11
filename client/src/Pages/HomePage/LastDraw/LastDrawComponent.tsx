import TitleComponent from "shared/components/TextComponents/TitleComponent";
import DrawComponent from "shared/components/DrawComponents";
import {IDraw} from "shared/types";

export interface LastDrawComponentProps {
	Draw: IDraw
	className?: string
}

function LastDrawComponent(props: LastDrawComponentProps) {

	return (
		<div className={props.className}>
			<TitleComponent>Last Draw</TitleComponent>
			<DrawComponent Draw={props.Draw}/>
		</div>
	)
}

export default LastDrawComponent;



