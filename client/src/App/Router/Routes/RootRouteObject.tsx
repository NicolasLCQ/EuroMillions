import {drawsRouteObject, homeRouteObject, NotFoundPage, notFoundRouteObject, RootPage, uploadRouteObject,} from "pages";
import {Navigate, RouteObject} from "react-router-dom";

const redirectOnHomePageByDefaultConfiguration = {index: true, element: <Navigate to={homeRouteObject.path} replace/>}

const rootRouteObject: RouteObject = {
	path: "/",
	element: <RootPage/>,
	errorElement: <NotFoundPage/>,
	children: [
		redirectOnHomePageByDefaultConfiguration,
		uploadRouteObject,
		drawsRouteObject,
		homeRouteObject,
		notFoundRouteObject
	]
}

export default rootRouteObject;
