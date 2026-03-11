import RootPage from "pages/RootPage.tsx";
import NotFoundPage from "pages/NotFoundPage/NotFoundPage.tsx";
import {Navigate, RouteObject} from "react-router-dom";
import uploadRouteObject from "pages/UploadPage/UploadRouteObject.tsx";
import homePageRouteObject from "pages/HomePage/HomePageRouteObject.tsx";

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
