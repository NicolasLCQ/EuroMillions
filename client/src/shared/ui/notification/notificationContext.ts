import {createContext} from 'react';

export interface NotificationContextValue {
  showSuccess: (message: string) => void;
  showError: (message: string) => void;
  clearNotification: () => void;
}

export const NotificationContext = createContext<NotificationContextValue | null>(null);
