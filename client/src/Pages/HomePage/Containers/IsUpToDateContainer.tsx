import ClickableComponentWrapper from "Components/TextComponents/ClickableComponentWrapper.tsx";
import PageErrorComponent from "Components/ErrorComponents/PageErrorComponents/PageErrorComponent.tsx";

export interface IsUpToDateContainerProps {
	onClick: () => void;
	isUpToDate: boolean;
}

function IsUpToDateContainer(props: IsUpToDateContainerProps) {

	const onClick = props.onClick;

	return (
		!props.isUpToDate &&
		<ClickableComponentWrapper onClick={onClick}>
			<PageErrorComponent>Draws are not up to date !! go on Upload Page to update !!</PageErrorComponent>
		</ClickableComponentWrapper>
	)
}

export default IsUpToDateContainer;