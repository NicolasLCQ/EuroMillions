import {createBrowserRouter, RouterProvider} from "react-router-dom";
import RootRouteObject from "./Routes/RootRouteObject.tsx";

const euroMillionsRouter = createBrowserRouter([RootRouteObject]);

const EuroMillionsRouter = () => {
	return <RouterProvider router={euroMillionsRouter}/>
}

export default EuroMillionsRouter;