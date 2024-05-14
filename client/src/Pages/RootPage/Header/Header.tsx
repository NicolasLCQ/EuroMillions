import './Header.css';
import packageJson from '../../../../package.json';

export default function Header() {
	return (
		<div className="Header">
			<div className="HeaderComponent">
				<div className="HeaderLogo">
					<img src="/FDJLogo.png" alt="FDJLogo"/>
				</div>
			</div>
			<div className="HeaderComponent">
				<div className="Version">
					v{packageJson.version}
				</div>
			</div>
		</div>
	)
}