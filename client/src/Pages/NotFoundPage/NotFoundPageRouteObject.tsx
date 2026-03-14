import {RouteObject} from "react-router-dom";
import NotFoundPage from "./NotFoundPage";

export const notFoundRouteObject: RouteObject = {
	path: "*",
	element: <NotFoundPage/>
};
