import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from 'react-router-dom';
import './const.css';

import {euroMillionsRouter} from "./Routes/routes.tsx";
import {EuroMillionsContextProviders} from "./Context/EuroMillionsContextProviders.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<EuroMillionsContextProviders>
			<RouterProvider router={euroMillionsRouter}>
			</RouterProvider>
		</EuroMillionsContextProviders>

	</React.StrictMode>,
)
//https://salehmubashar.com/blog/how-to-create-active-links-using-react-router-v6