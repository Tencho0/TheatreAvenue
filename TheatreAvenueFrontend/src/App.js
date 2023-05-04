// Importing necessary modules
import React from 'react'
import { TheatreRouter } from './components/TheatreRouter/TheatreRouter'

// Defining main component
function App() {
  // Returning the JSX
  return (
    <div className="App">
      <TheatreRouter />
    </div>
  )
}

// Exporting the main component as default
export default App

//This code exports the main component of the application, which is App.
//It imports React and TheatreRouter from their respective modules.
//The App component returns the JSX of the entire application,
//which includes the TheatreRouter component that renders the various routes for the application.
//When this component is rendered, it creates a <div> element with the class name "App" and renders the TheatreRouter component inside it.
