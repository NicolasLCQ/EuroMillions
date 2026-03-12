import {RouteObject} from "react-router-dom";
import NotFoundPage from "./NotFoundPage";

const notFoundRouteObject: RouteObject = {
	path: "*",
	element: <NotFoundPage/>
};

export default notFoundRouteObject;
