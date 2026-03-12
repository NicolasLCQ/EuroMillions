import RootPage from "pages/RootPage";
import NotFoundPage from "pages/NotFoundPage";
import {homeRouteObject} from "pages/HomePage";
import {uploadRouteObject} from "pages/UploadPage";
import {notFoundRouteObject} from "pages/NotFoundPage";
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
		notFoundRouteObject
	]
}

export default rootRouteObject;
