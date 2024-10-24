import {RouteObject} from "react-router-dom";
import UploadPage from "./UploadPage.tsx";

const uploadRouteObject: RouteObject = {
	path: "/upload",
	element: <UploadPage/>
};

export default uploadRouteObject;