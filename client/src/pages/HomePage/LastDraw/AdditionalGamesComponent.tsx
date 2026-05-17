import {TextComponent} from "shared/components";
import {IDrawAdditionalGames} from "shared/types";
import styles from "./LastDrawComponent.module.css";

const getAdditionalGames = (draw: IDrawAdditionalGames) => [
	{label: "Joker+", value: draw.jokerPlusNumber},
	{label: "My Million", value: draw.myMillionNumber},
	{label: "Exceptional EuroMillions", value: draw.exceptionalEuroMillionsDrawNumber},
].filter(additionalGame => !!additionalGame.value);

export interface AdditionalGamesComponentProps {
	Draw: IDrawAdditionalGames
}

function AdditionalGamesComponent(props: AdditionalGamesComponentProps) {
	const additionalGames = getAdditionalGames(props.Draw);

	return (
		<div className={styles.additionalGames}>
			{additionalGames.length > 0
				? additionalGames.map(additionalGame => (
					<div className={styles.additionalGame} key={additionalGame.label}>
						<span className={styles.additionalGameLabel}>{additionalGame.label}</span>
						<span className={styles.additionalGameValue}>{additionalGame.value}</span>
					</div>
				))
				: <TextComponent className={styles.emptyState}>No additional game result</TextComponent>}
		</div>
	);
}

export default AdditionalGamesComponent;
