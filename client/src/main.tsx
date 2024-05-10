import React from 'react'
import ReactDOM from 'react-dom/client'
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import Header from "./Composants/Header/Header.tsx";
import './const.css';
import EuroMillionsApp from "./EuroMillionsApp.tsx";

const router = createBrowserRouter([
	{
		path: "/",
		element: <EuroMillionsApp/>,
	},
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<Header/>
		<RouterProvider router={router}/>
	</React.StrictMode>,
)
