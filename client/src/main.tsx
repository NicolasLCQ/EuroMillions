import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from 'react-router-dom';
import './const.css';

import {euroMillionsRouter} from "./Routes/routes.tsx";
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";

const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<QueryClientProvider client={queryClient}>
				<RouterProvider router={euroMillionsRouter}>
				</RouterProvider>
		</QueryClientProvider>
	</React.StrictMode>,
)
//https://salehmubashar.com/blog/how-to-create-active-links-using-react-router-v6