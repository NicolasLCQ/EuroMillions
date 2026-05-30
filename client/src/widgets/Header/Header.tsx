import styles from './Header.module.css';

export interface IHeaderProps {
  version: string;
}

export default function Header(props: IHeaderProps) {
  return (
    <header className={styles.header}>
      <div className={styles.headerInner}>
        <div className={styles.headerComponent}>
          <div className={styles.headerLogo}>
            <img src='/images/FDJLogo.png' alt='FDJLogo' />
          </div>
        </div>
        <div className={styles.headerComponent}>
          <div className={styles.version}>v{props.version}</div>
        </div>
      </div>
    </header>
  );
}
