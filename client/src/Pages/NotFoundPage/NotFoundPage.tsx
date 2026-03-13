import styles from "./NotFoundPage.module.css";

export default function NotFoundPage() {
	return (
		<div className={styles.notFound}>
			<h1 className={styles.code}>
				404
			</h1>
			<h2 className={styles.message}>Sorry, this page does not exist O_O</h2>
		</div>
	)
}
