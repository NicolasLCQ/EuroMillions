import RootPage from "pages/RootPage";
import NotFoundPage from "pages/NotFoundPage";
import {uploadRouteObject, homeRouteObject} from "pages";
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
		homeRouteObject,
		{
			path: "*",
			element: <NotFoundPage/>
		}
	]
}

export default rootRouteObject;
