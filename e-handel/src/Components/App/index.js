import React, { Component } from 'react'
import Wrapper from '../Wrapper/'
import CartWrapper from '../CartWrapper'
import Nav from '../Nav/'
import { BrowserRouter as Router, Route, Link } from "react-router-dom"
import Checkout from '../Checkout'
class App extends Component {

  render() {
    return (
      <div className="App">
        <Nav/>
        <Route exact path="/" />
        <Route path="/Products" component={Wrapper} />
       	<Route path="/Cart" component={CartWrapper} />
       	<Route path="/Order" component={Checkout} />
      </div>
    );
  }
}

export default App;