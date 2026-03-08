import React from 'react';
import styles from './PageErrorComponent.module.css';

interface IPageErrorComponentProps extends React.PropsWithChildren {
	className?: string
}

function PageErrorComponent(props: IPageErrorComponentProps) {
	const className = props.className ? `${styles.pageError} ${props.className}` : styles.pageError;

	return (
		<div className={className}>
			{props.children}
		</div>
	)
}

export default PageErrorComponent;
