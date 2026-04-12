import React, {createContext, useContext, useEffect, useState} from "react";
import {GlobalNotificationComponent} from "shared/components";

type NotificationType = "success" | "error";

interface INotificationState {
	type: NotificationType;
	message: string;
}

interface INotificationContext {
	showSuccess: (message: string) => void;
	showError: (message: string) => void;
	clearNotification: () => void;
}

const NotificationContext = createContext<INotificationContext | null>(null);

export const useNotification: () => INotificationContext = () => {
	const context = useContext(NotificationContext);

	if (!context) {
		throw new Error("useNotification must be used inside NotificationProvider");
	}

	return context;
};

type INotificationProviderProps = React.PropsWithChildren

function NotificationProvider(props: INotificationProviderProps) {
	const [notification, setNotification] = useState<INotificationState | null>(null);

	const clearNotification = () => {
		setNotification(null);
	};

	const showSuccess = (message: string) => {
		setNotification({type: "success", message});
	};

	const showError = (message: string) => {
		setNotification({type: "error", message});
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
			{notification && (
				<GlobalNotificationComponent
					type={notification.type}
					message={notification.message}
				/>
			)}
		</NotificationContext>
	);
}

export default NotificationProvider;
