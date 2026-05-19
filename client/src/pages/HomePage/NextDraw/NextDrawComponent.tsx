import styles from './NextDrawComponent.module.css';
import {TextComponent, TitleComponent} from 'shared/components';
import {IFdjMoneyAmount} from 'shared/types';

export interface INextDrawComponentProps {
  Date: Date;
  estimatedJackpot?: IFdjMoneyAmount | null;
  className?: string;
}

const formatJackpotAmount = (estimatedJackpot: IFdjMoneyAmount) =>
  new Intl.NumberFormat('fr-FR', {
    minimumFractionDigits: estimatedJackpot.scale,
    maximumFractionDigits: estimatedJackpot.scale,
  }).format(estimatedJackpot.value / 10 ** estimatedJackpot.scale);

const formatDrawDate = (drawDate: Date) =>
  new Intl.DateTimeFormat('en-GB', {
    weekday: 'long',
    day: 'numeric',
    month: 'long',
    year: 'numeric',
  }).format(new Date(drawDate));

function NextDrawComponent(props: INextDrawComponentProps) {
  const className = props.className ? `${styles.nextDraw} ${props.className}` : styles.nextDraw;

  if (!props.Date) {
    return null;
  }

  const date = new Date(props.Date);

  return (
    <div className={className}>
      <TitleComponent>Next Draw</TitleComponent>
      <TextComponent className={styles.nextDrawDate}>{formatDrawDate(date)}</TextComponent>
      {props.estimatedJackpot && (
        <div className={styles.estimatedJackpot}>
          <TextComponent className={styles.jackpotLabel}>Estimated jackpot</TextComponent>
          <TextComponent className={styles.jackpotAmount}>
            <span>{formatJackpotAmount(props.estimatedJackpot)}</span>
            <span className={styles.jackpotCurrency}>{props.estimatedJackpot.currency}</span>
          </TextComponent>
        </div>
      )}
    </div>
  );
}

export default NextDrawComponent;
