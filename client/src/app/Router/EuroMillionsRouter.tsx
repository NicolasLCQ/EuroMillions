import {createBrowserRouter, RouterProvider} from "react-router-dom";
import { rootRouteObject } from "app/Router/Routes";

const euroMillionsRouter = createBrowserRouter([rootRouteObject]);

const EuroMillionsRouter = () => {
	return <RouterProvider router={euroMillionsRouter}/>
}

export default EuroMillionsRouter;

