import RootPage from "../../../Pages/RootPage/RootPage.tsx";
import NotFoundPage from "../../../Pages/NotFoundPage/NotFoundPage.tsx";
import {RouteObject} from "react-router-dom";
import uploadRouteObject from "../../../Pages/UploadPage/UploadRouteObject.tsx";

const rootRouteObject: RouteObject = {
	path: "/",
	element: <RootPage/>,
	errorElement: <NotFoundPage/>,
	children:[
		uploadRouteObject
	]
}

export default rootRouteObject;