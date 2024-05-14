import {RouteObject} from "react-router-dom";
import UploadPage from "./UploadPage.tsx";

export const uploadRouteObject: RouteObject = {
	path: "/upload",
	element: <UploadPage/>
}