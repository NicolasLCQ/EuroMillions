import './DefaultButtonComponent.css';

interface ButtonComponentsProps {
	text?: string
}

export default function ButtonComponents(props: ButtonComponentsProps) {
	return (
		<button className="ButtonComponents">{props.text}</button>
	)
}