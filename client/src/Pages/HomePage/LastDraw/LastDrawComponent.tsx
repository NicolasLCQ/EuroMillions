import TitleComponent from "shared/components/TextComponents/TitleComponent/TitleComponent.tsx";
import DrawComponent from "shared/components/DrawComponents/DrawComponent.tsx";
import {IDraw} from "shared/types/IDraw.ts";

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


