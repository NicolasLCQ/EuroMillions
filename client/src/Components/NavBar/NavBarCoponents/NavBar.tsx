import NavBarComponent from "./NavBarComponent.tsx";
import {ComponentType} from "react";

interface INavBarProps {
	NavBarComponents?: ComponentType<NavBarComponent>[] | undefined;
}

export default function NavBar(props: INavBarProps) {
	return (
		<div className="NavBar">
			{props.NavBarComponents}
		</div>
	)
}