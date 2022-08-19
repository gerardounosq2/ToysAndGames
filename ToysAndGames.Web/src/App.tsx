import './App.css'
import { Header } from 'semantic-ui-react'
import GridComponent from './features/GridComponent'
import { Route, Switch, useLocation } from "react-router-dom"
import ProductForm from './features/ProductForm'
import { observer } from 'mobx-react-lite'
import { useStore } from './stores/store'
import { useEffect } from 'react'

function App() {
  const location = useLocation();

  return (
    <div className="App">
      <Header as="h1" content="Unosquare Toys and Games" />
      <Route path={'/(.+)'}
        render={() => (
          <Switch>
            <Route path='/products' component={GridComponent} />
            <Route key={location.key} path={['/create', '/edit/:id']} component={ProductForm} />
          </Switch>
        )}
      />
    </div>
  )
}

export default observer(App);