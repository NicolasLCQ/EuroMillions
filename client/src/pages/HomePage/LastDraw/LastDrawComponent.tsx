import {DrawComponent, TextComponent, TitleComponent} from 'shared/components';
import {IDraw} from 'shared/types';
import styles from './LastDrawComponent.module.css';
import AdditionalGamesComponent from './AdditionalGamesComponent.tsx';
import PrizeRanksTableComponent from './PrizeRanksTableComponent.tsx';

const formatDrawDate = (drawDate: string) =>
  new Intl.DateTimeFormat('en-US', {
    weekday: 'long',
    month: 'long',
    day: 'numeric',
    year: 'numeric',
  }).format(new Date(drawDate));

export interface LastDrawComponentProps {
  Draw: IDraw | null | undefined;
  className?: string;
}

function LastDrawComponent(props: LastDrawComponentProps) {
  const className = props.className ? `${styles.lastDraw} ${props.className}` : styles.lastDraw;
  const isDraw = !!props.Draw;

  if (!isDraw) {
    return (
      <div className={className}>
        <TitleComponent>Last Draw</TitleComponent>
        <TextComponent>No draw found</TextComponent>
      </div>
    );
  }

  return (
    <div className={className}>
      <TitleComponent>Last Draw</TitleComponent>
      <TextComponent className={styles.drawDate}>{formatDrawDate(props.Draw.drawDate)}</TextComponent>
      <div className={styles.drawSummary}>
        <div className={styles.drawDetails}>
          <DrawComponent Draw={props.Draw} className={styles.drawResult} />
          <AdditionalGamesComponent Draw={props.Draw} />
        </div>
        <PrizeRanksTableComponent PrizeRanks={props.Draw.euroMillionsPrizeRanks} />
      </div>
    </div>
  );
}

export default LastDrawComponent;
