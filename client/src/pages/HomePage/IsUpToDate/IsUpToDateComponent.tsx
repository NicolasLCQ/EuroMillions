import {ClickableComponentWrapper, PageErrorComponent} from "shared/components";

export interface IsUpToDateComponentProps {
	onClick: () => void;
	isUpToDate: boolean;
}

function IsUpToDateComponent(props: IsUpToDateComponentProps) {
	const onClick = props.onClick;

	return (
		!props.isUpToDate &&
		<ClickableComponentWrapper onClick={onClick}>
			<PageErrorComponent>
				Draws are not up to date !! go on Upload Page to update !!
			</PageErrorComponent>
		</ClickableComponentWrapper>
	)
}

export default IsUpToDateComponent;


