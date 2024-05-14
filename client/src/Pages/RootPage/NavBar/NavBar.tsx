import NavBarComponent from "../../../Components/NavBarComponent/NavBarComponent.tsx";
import {INavBarComponentProps} from "../../../Components/NavBarComponent/NavBarElement/NavBarElement.tsx";

const NavBarInformations:INavBarComponentProps[] = [
	{
		text: "Tirages",
		link: "/draws"
	},
	{
		text: "Statistiques",
		link: "/statistics"
	},
	{
		text: "Upload",
		link: "/upload"
	}
]

export default function NavBar() {
	return(
		<NavBarComponent textAndLinks={NavBarInformations} />
	)
}