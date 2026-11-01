import type {IGetNextDrawEstimatedJackpotResponse} from '../api/endpoints/IGetNextDrawEstimatedJackpotResponse';

export const formatJackpotAmount = (estimatedJackpot: IGetNextDrawEstimatedJackpotResponse) =>
  new Intl.NumberFormat('fr-FR', {
    maximumFractionDigits: 2,
  }).format(estimatedJackpot.amount);

export const formatDrawDate = (drawDate: Date) =>
  new Intl.DateTimeFormat('en-GB', {
    weekday: 'long',
    day: 'numeric',
    month: 'long',
    year: 'numeric',
  }).format(new Date(drawDate));
