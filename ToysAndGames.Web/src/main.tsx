import { createBrowserHistory } from 'history'
import React from 'react'
import ReactDOM from 'react-dom/client'
import { Router } from 'react-router-dom'
import App from './App'
import './index.css'

export const history = createBrowserHistory();

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  // <React.StrictMode>
  <Router history={history}>
    <App />
  </Router>
  // </React.StrictMode>
)
