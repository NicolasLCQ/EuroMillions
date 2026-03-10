import ClickableComponentWrapper from "../../../Shared/Components/TextComponents/ClickableComponentWrapper.tsx";
import PageErrorComponent from "../../../Shared/Components/ErrorComponents/PageErrorComponents/PageErrorComponent.tsx";

export interface IsUpToDateComponentProps {
	onClick: () => void;
	isUpToDate: boolean;
}

function IsUpToDateComponent(props: IsUpToDateComponentProps) {

	const onClick = props.onClick;

	return (
		!props.isUpToDate &&
		<ClickableComponentWrapper onClick={onClick}>
			<PageErrorComponent>Draws are not up to date !! go on Upload Page to update !!</PageErrorComponent>
		</ClickableComponentWrapper>
	)
}

export default IsUpToDateComponent;
