import {useNavigate} from 'react-router-dom';
import {ROUTES} from '@/shared/config';

export function useUpdateDrawsNavigation() {
  const navigate = useNavigate();

  return {goToUploadPage: () => navigate(ROUTES.updateDraws)};
}
