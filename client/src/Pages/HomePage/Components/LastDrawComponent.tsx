import TitleComponent from "../../../Shared/Components/TextComponents/TitleComponent/TitleComponent.tsx";
import DrawComponent from "../../../Shared/Components/DrawComponents/DrawComponent.tsx";
import {IDraw} from "Models/DrawModels/IDraw.ts";

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

