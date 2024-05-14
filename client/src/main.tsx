import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from 'react-router-dom';
import './const.css';

import {euroMillionsRouter} from "./Routes/routes.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<RouterProvider router={euroMillionsRouter}>
		</RouterProvider>
	</React.StrictMode>,
)
//https://salehmubashar.com/blog/how-to-create-active-links-using-react-router-v6