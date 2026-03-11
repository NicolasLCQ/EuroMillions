import {RootPage} from "pages";
import NotFoundPage from "pages/NotFoundPage";
import {Navigate, RouteObject} from "react-router-dom";
import {uploadRouteObject} from "pages/UploadPage";
import {homeRouteObject} from "pages/HomePage";

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

