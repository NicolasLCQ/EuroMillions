import {IDrawPrizeRank} from "shared/types";
import styles from "./LastDrawComponent.module.css";

const formatNumber = (value: number) => new Intl.NumberFormat("fr-FR").format(value);

const formatPrize = (value: number) => new Intl.NumberFormat("fr-FR", {
	style: "currency",
	currency: "EUR",
}).format(value);

export interface PrizeRanksTableComponentProps {
	PrizeRanks: IDrawPrizeRank[]
}

function PrizeRanksTableComponent(props: PrizeRanksTableComponentProps) {
	if (props.PrizeRanks.length === 0) {
		return null;
	}

	return (
		<div className={styles.prizeRanksSection}>
			<div className={styles.prizeRanksTableWrapper}>
				<table className={styles.prizeRanksTable}>
					<thead>
						<tr>
							<th scope="col">Rang</th>
							<th scope="col">Vainqueurs France</th>
							<th scope="col">Vainqueurs Europe</th>
							<th scope="col">Gain</th>
						</tr>
					</thead>
					<tbody>
						{props.PrizeRanks.map(prizeRank => (
							<tr key={prizeRank.rank}>
								<td data-label="Rang">{prizeRank.rank}</td>
								<td data-label="Vainqueurs France">{formatNumber(prizeRank.winnersFrance)}</td>
								<td data-label="Vainqueurs Europe">{formatNumber(prizeRank.winnersEurope)}</td>
								<td data-label="Gain">{formatPrize(prizeRank.prize)}</td>
							</tr>
						))}
					</tbody>
				</table>
			</div>
		</div>
	);
}

export default PrizeRanksTableComponent;
