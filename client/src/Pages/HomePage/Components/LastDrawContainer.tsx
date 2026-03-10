import TitleComponent from "../../../Shared/Components/TextComponents/TitleComponent/TitleComponent.tsx";
import DrawComponent from "../../../Shared/Components/DrawComponents/DrawComponent.tsx";
import {IDraw} from "Models/DrawModels/IDraw.ts";

export interface LastDrawContainerProps {
	Draw: IDraw
	className?: string
}

function LastDrawContainer(props: LastDrawContainerProps) {

	return (
		<div className={props.className}>
			<TitleComponent>Last Draw</TitleComponent>
			<DrawComponent Draw={props.Draw}/>
		</div>
	)
}

export default LastDrawContainer;
