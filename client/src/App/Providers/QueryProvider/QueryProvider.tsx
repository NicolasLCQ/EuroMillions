import {QueryClientProvider} from "@tanstack/react-query";
import queryClient from "./QueryClient.ts";

export interface IQueryProviderProps {
	children: React.ReactNode
}

const QueryProvider = ({children}:IQueryProviderProps) => {

	return(
		<QueryClientProvider client={queryClient}>
			{children}
		</QueryClientProvider>
	)
}

export default QueryProvider;