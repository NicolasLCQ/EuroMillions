import React from 'react';

interface IClickableComponentWrapperProps extends React.PropsWithChildren {
	onClick: () => void;
	className?: string;
}

function ClickableComponentWrapper(props: IClickableComponentWrapperProps) {
	return (
		<div
			onClick={props.onClick}
			className={props.className ?? `clickable-wrapper`}
			style={{cursor: 'pointer'}}
			role="button"
		>
			{props.children}
		</div>
	);
}

export default ClickableComponentWrapper;
