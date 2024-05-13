import {RouteObject} from "react-router-dom";
import NotFoundPage from "./NotFoundPage.tsx";

export const notFoundRouteObject: RouteObject = {
	errorElement: <NotFoundPage/>
}