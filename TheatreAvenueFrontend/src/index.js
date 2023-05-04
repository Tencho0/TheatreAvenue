// Importing necessary modules
import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App'
import reportWebVitals from './reportWebVitals'

// Logging environment
console.log('Environment')
console.log(process.env.NODE_ENV)

// Creating root element for rendering
const root = ReactDOM.createRoot(document.getElementById('root'))

// Rendering the App component
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals()

//This code is the entry point for the application.
//It imports necessary modules such as React, ReactDOM, ./index.css, App and reportWebVitals.
//It logs the current environment and creates a root element using ReactDOM.createRoot().
//Finally, it renders the App component wrapped in a React.StrictMode component inside the root element.

//When the application runs, this code is responsible for rendering the entire application on the DOM by calling ReactDOM.createRoot() and root.render().
//The React.StrictMode component is used to trigger additional checks and warnings for potential problems in the application.
//The console.log() statements are used to log the current environment.
