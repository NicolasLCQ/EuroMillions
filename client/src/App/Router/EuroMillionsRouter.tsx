import {createBrowserRouter, RouterProvider} from "react-router-dom";
import rootRouteObject from "app/router/routes";

const euroMillionsRouter = createBrowserRouter([rootRouteObject]);

const EuroMillionsRouter = () => {
	return <RouterProvider router={euroMillionsRouter}/>
}

export default EuroMillionsRouter;

