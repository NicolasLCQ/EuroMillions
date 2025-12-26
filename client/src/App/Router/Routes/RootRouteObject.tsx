import RootPage from "../../../Pages/RootPage/RootPage.tsx";
import NotFoundPage from "../../../Pages/NotFoundPage/NotFoundPage.tsx";
import {Navigate, RouteObject} from "react-router-dom";
import uploadRouteObject from "../../../Pages/UploadPage/UploadRouteObject.tsx";
import homePageRouteObject from "../../../Pages/HomePage/HomePageRouteObject.tsx";

const rootRouteObject: RouteObject = {
	path: "/",
	element: <RootPage/>,
	errorElement: <NotFoundPage/>,
	children: [
		{
			index: true,
			element: <Navigate to={homePageRouteObject.path} replace/>
		},
		uploadRouteObject,
		homePageRouteObject
	]
}

export default rootRouteObject;