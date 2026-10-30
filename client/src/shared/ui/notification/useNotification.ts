import {useContext} from 'react';
import {NotificationContext, type NotificationContextValue} from './notificationContext';

export const useNotification = (): NotificationContextValue => {
  const context = useContext(NotificationContext);

  if (!context) {
    throw new Error('useNotification must be used inside NotificationProvider');
  }

  return context;
};
