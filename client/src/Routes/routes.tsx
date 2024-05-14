import {createBrowserRouter} from "react-router-dom";
import {uploadRouteObject} from "../Pages/UploadPage/UploadRouteObject.tsx";
import RootPage from "../Pages/RootPage/RootPage.tsx";
import NotFoundPage from "../Pages/NotFoundPage/NotFoundPage.tsx";

export const euroMillionsRouter = createBrowserRouter([
	{
		path: "/",
		element: <RootPage/>,
		errorElement: <NotFoundPage/>,
		children:[
			uploadRouteObject
		]
	}
]);