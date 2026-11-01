import styles from './NextDrawComponent.module.css';
import {TextComponent} from '@/shared/ui/text';
import {TitleComponent} from '@/shared/ui/title';

export interface INextDrawComponentProps {
  date?: string;
  estimatedJackpot?: {amount: string; currency: string} | null;
  className?: string;
}

function NextDrawComponent(props: INextDrawComponentProps) {
  const className = props.className ? `${styles.nextDraw} ${props.className}` : styles.nextDraw;

  if (!props.date) {
    return null;
  }

  return (
    <div className={className}>
      <TitleComponent>Next Draw</TitleComponent>
      <TextComponent className={styles.nextDrawDate}>{props.date}</TextComponent>
      {props.estimatedJackpot && (
        <div className={styles.estimatedJackpot}>
          <TextComponent className={styles.jackpotLabel}>Estimated jackpot</TextComponent>
          <TextComponent className={styles.jackpotAmount}>
            <span>{props.estimatedJackpot.amount}</span>
            <span className={styles.jackpotCurrency}>{props.estimatedJackpot.currency}</span>
          </TextComponent>
        </div>
      )}
    </div>
  );
}

export default NextDrawComponent;
