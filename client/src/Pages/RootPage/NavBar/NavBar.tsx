import {INavBarComponentProps} from "../../../Components/NavBarComponents/NavBarElements/NavBarElement.tsx";
import NavBarComponent from "../../../Components/NavBarComponents/NavBarComponent.tsx";
import uploadRouteObject from "../../UploadPage/UploadRouteObject.tsx";

const NavBarInformations: INavBarComponentProps[] = [
	{
		text: "Tirages",
		link: ""
	},
	{
		text: "Statistiques",
		link: ""
	},
	{
		text: "Upload",
		link: uploadRouteObject.path
	}
]

export default function NavBar() {
	return (
		<NavBarComponent textAndLinks={NavBarInformations} />
	)
}