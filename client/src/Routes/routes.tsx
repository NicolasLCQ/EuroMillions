import {createBrowserRouter} from "react-router-dom";
import {notFoundRouteObject} from "../Pages/NotFoundPage/NotFoundRouteObject.tsx";
import {uploadRouteObject} from "../Pages/UploadPage/UploadRouteObject.tsx";

export const euroMillionsRouter = createBrowserRouter([
	notFoundRouteObject,
	uploadRouteObject
]);