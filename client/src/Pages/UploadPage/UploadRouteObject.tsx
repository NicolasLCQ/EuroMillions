import {RouteObject} from "react-router-dom";
import EuroMillionsApp from "./EuroMillionsApp.tsx";

export const uploadRouteObject: RouteObject = {
	path: "/",
	element: <EuroMillionsApp/>
}