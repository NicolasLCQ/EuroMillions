import {UploadPageConstextProvider} from "../Pages/UploadPage/UploadPageContext/UploadPageContext.tsx";

export const EuroMillionsContextProviders = ({children}) => {
	return (
		<UploadPageConstextProvider>
			{children}
		</UploadPageConstextProvider>
	)
}