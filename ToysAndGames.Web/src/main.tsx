import { createBrowserHistory } from 'history'
import React from 'react'
import ReactDOM from 'react-dom/client'
import { Router } from 'react-router-dom'
import App from './App'
import './index.css'
import { store, StoreContext } from './stores/store'

export const history = createBrowserHistory();

const container = document.getElementById('root') as HTMLElement;
const root = ReactDOM.createRoot(container);

root.render(
  <StoreContext.Provider value={store}>
    <Router history={history}>
      <App />
    </Router>
  </StoreContext.Provider>
)
