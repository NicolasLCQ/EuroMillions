import { useState } from 'react'
import './App.css'

function EuroMillionsApp() {
  const [count] = useState(0)

  return (
    "Hello World" + {count}
  );
}

export default EuroMillionsApp
