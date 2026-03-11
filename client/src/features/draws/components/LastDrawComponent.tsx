import TitleComponent from "shared/ui/TextComponents/TitleComponent/TitleComponent.tsx";
import DrawComponent from "shared/ui/DrawComponents/DrawComponent.tsx";
import {IDraw} from "features/draws/model/IDraw.ts";

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

