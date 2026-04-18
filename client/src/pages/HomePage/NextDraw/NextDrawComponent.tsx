import styles from './NextDrawComponent.module.css';
import {TextComponent, TitleComponent} from "shared/components";

export interface INextDrawComponentProps {
	Date: Date
	className?: string
}

function NextDrawComponent(props: INextDrawComponentProps) {
	const className = props.className ? `${styles.nextDraw} ${props.className}` : styles.nextDraw;

	if (!props.Date) {
		return null;
	}

	const date = new Date(props.Date);

	return (
		<div className={className}>
			<TitleComponent>Next Draw</TitleComponent>
			<TextComponent className={styles.nextDrawDate}>
				{date.getDate()}/{date.getMonth() + 1}/{date.getFullYear()}
			</TextComponent>
		</div>
	)
}

export default NextDrawComponent;



