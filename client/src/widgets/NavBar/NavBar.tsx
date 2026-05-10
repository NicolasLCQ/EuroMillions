import {INavBarComponentProps} from "shared/components/NavBarComponents/NavBarElements";
import { NavBarComponent } from "shared/components/NavBarComponents";
import {homeRouteObject} from "pages/HomePage";
import {uploadRouteObject} from "pages/UploadPage";
import {drawsRouteObject} from "pages/DrawsPage";

const NavBarInformations: INavBarComponentProps[] = [
	{
		text: "Home",
		link: homeRouteObject.path
	},
	{
		text: "Draws",
		link: drawsRouteObject.path
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


