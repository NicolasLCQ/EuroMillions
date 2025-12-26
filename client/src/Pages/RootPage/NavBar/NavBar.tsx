import {INavBarComponentProps} from "../../../Components/NavBarComponents/NavBarElements/NavBarElement.tsx";
import NavBarComponent from "../../../Components/NavBarComponents/NavBarComponent.tsx";
import uploadRouteObject from "../../UploadPage/UploadRouteObject.tsx";
import homeRouteObject from "../../../Pages/HomePage/HomePageRouteObject.tsx";

const NavBarInformations: INavBarComponentProps[] = [
	{
		text: "Home",
		link: homeRouteObject.path
	},
	{
		text: "Draws",
		link: ""
	},
	{
		text: "Statistics",
		link: ""
	},
	{
		text: "Upload",
		link: uploadRouteObject.path
	},
]

export default function NavBar() {
	return (
		<NavBarComponent textAndLinks={NavBarInformations}/>
	)
}