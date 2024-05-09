import { useState } from 'react'

function EuroMillionsApp() {
  const [count, setCount] = useState(0)

  return (
    <>
      Hello World !
      {count}
      <button onClick={() => setCount(count+1)}>ADD</button>
    </>
  );
}

export default EuroMillionsApp
