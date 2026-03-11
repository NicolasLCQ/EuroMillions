import RootPage from "pages";
import NotFoundPage, {uploadRouteObject, homeRouteObject} from "pages";
import {Navigate, RouteObject} from "react-router-dom";

const rootRouteObject: RouteObject = {
	path: "/",
	element: <RootPage/>,
	errorElement: <NotFoundPage/>,
	children: [
		{
			index: true,
			element: <Navigate to={homeRouteObject.path} replace/>
		},
		uploadRouteObject,
		homeRouteObject
	]
}

export default rootRouteObject;
