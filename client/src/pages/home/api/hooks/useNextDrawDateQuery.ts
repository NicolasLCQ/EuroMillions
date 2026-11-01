import {useQuery} from '@tanstack/react-query';
import {getNextDrawDate} from '../endpoints/getNextDrawDate';

export const useNextDrawDateQuery = () =>
  useQuery({
    queryKey: ['nextDrawDate'],
    queryFn: getNextDrawDate,
  });
