import {useEffect, useState, type PropsWithChildren} from 'react';
import GlobalNotificationComponent from './GlobalNotificationComponent';
import {NotificationContext} from './notificationContext';

type NotificationType = 'success' | 'error';

interface INotificationState {
  type: NotificationType;
  message: string;
}

export type NotificationProviderProps = PropsWithChildren;

function NotificationProvider(props: NotificationProviderProps) {
  const [notification, setNotification] = useState<INotificationState | null>(null);

  const clearNotification = () => {
    setNotification(null);
  };

  const showSuccess = (message: string) => {
    setNotification({type: 'success', message});
  };

  const showError = (message: string) => {
    setNotification({type: 'error', message});
  };

  useEffect(() => {
    if (!notification) {
      return;
    }

    const timeoutId = window.setTimeout(() => {
      clearNotification();
    }, 4000);

    return () => {
      window.clearTimeout(timeoutId);
    };
  }, [notification]);

  return (
    <NotificationContext value={{showSuccess, showError, clearNotification}}>
      {props.children}
      {notification && <GlobalNotificationComponent type={notification.type} message={notification.message} />}
    </NotificationContext>
  );
}

export default NotificationProvider;
