import {RouteObject} from "react-router-dom";
import {DrawsPage} from "pages/DrawsPage";

export const drawsRouteObject: RouteObject = {
	path: "/draws",
	element: <DrawsPage/>
};
