import styles from './Header.module.css';
import packageJson from '../../../package.json';

export default function Header() {
	return (
		<header className={styles.header}>
			<div className={styles.headerInner}>
				<div className={styles.headerComponent}>
					<div className={styles.headerLogo}>
						<img src="/images/FDJLogo.png" alt="FDJLogo"/>
					</div>
				</div>
				<div className={styles.headerComponent}>
					<div className={styles.version}>
						v{packageJson.version}
					</div>
				</div>
			</div>
		</header>
	)
}
