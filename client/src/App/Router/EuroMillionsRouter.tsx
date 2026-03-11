import {createBrowserRouter, RouterProvider} from "react-router-dom";
import {RootRouteObject} from "app/router/routes";

const euroMillionsRouter = createBrowserRouter([RootRouteObject]);

const EuroMillionsRouter = () => {
	return <RouterProvider router={euroMillionsRouter}/>
}

export default EuroMillionsRouter;

