import {INavBarComponentProps} from "../../../Components/NavBarComponents/NavBarElements/NavBarElement.tsx";
import NavBarComponent from "../../../Components/NavBarComponents/NavBarComponent.tsx";

const NavBarInformations: INavBarComponentProps[] = [
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
	return (
		<NavBarComponent textAndLinks={NavBarInformations} />
	)
}