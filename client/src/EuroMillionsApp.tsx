import {useState} from 'react'

function EuroMillionsApp() {
	const [count, setCount] = useState(0)

	return (
		<div className="EuroMillionsApp">
			Hello World !<br/>
			{count}<br/>
			<button onClick={() => setCount(count + 1)}>ADD</button>
		</div>
	);
}

export default EuroMillionsApp
