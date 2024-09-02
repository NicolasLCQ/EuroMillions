import {UploadPageContextProvider} from "../Pages/UploadPage/UploadPageContext/UploadPageContext.tsx";

export const EuroMillionsContextProviders = ({children}) => {
	return (
		<UploadPageContextProvider>
			{children}
		</UploadPageContextProvider>
	)
}