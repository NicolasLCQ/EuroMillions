import React from 'react';
import './PageErrorComponent.css';

interface IPageErrorComponentProps extends React.PropsWithChildren {
	className?: string
}

function PageErrorComponent(props: IPageErrorComponentProps) {
	return (
		<div className={props.className ?? "PageErrorComponent"}>
			{props.children}
		</div>
	)
}

export default PageErrorComponent;