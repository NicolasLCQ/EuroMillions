import styles from "./GlobalNotificationComponent.module.css";

export interface IGlobalNotificationComponentProps {
	type: "success" | "error";
	message: string;
}

function GlobalNotificationComponent(props: IGlobalNotificationComponentProps) {
	const toneClassName = props.type === "success" ? styles.success : styles.error;

	return (
		<div className={styles.notificationContainer} aria-live="polite" aria-atomic="true">
			<div className={`${styles.notification} ${toneClassName}`}>
				{props.message}
			</div>
		</div>
	);
}

export default GlobalNotificationComponent;