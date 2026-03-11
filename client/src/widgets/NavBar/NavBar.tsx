import {INavBarComponentProps} from "shared/components/NavBarComponents/NavBarElements/NavBarElement.tsx";
import NavBarComponent from "shared/components/NavBarComponents/NavBarComponent.tsx";
import uploadRouteObject from "pages/UploadPage/UploadRouteObject.tsx";
import homeRouteObject from "pages/HomePage/HomePageRouteObject.tsx";

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

