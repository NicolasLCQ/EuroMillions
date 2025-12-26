import {RouteObject} from "react-router-dom";
import HomePage from "./HomePage.tsx";

const homeRouteObject: RouteObject = {
	path: "/home",
	element: <HomePage/>
};

export default homeRouteObject;