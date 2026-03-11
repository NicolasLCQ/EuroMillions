import RootPage from "pages";
import NotFoundPage from "pages";
import {Navigate, RouteObject} from "react-router-dom";
import {uploadRouteObject} from "pages";
import {homeRouteObject} from "pages";

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

