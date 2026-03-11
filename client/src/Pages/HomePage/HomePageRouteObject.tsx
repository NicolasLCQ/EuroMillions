import {RouteObject} from "react-router-dom";
import HomePage from "pages/HomePage";

const homeRouteObject: RouteObject = {
	path: "/home",
	element: <HomePage/>
};

export default homeRouteObject;