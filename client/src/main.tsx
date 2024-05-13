import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from 'react-router-dom';
import Header from "./Composants/Header/Header.tsx";
import './const.css';
import NavBar from './Composants/NavBar/NavBar';
import {euroMillionsRouter} from "./Routes/routes.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<Header/>
		<NavBar/>
		<RouterProvider router={euroMillionsRouter}/>
	</React.StrictMode>,
)
