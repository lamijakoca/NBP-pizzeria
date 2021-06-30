import React from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom';
import Admin from './components/Admin';
import Customer from './components/Customer';
import Home from './components/Home';
import Login from './components/Login';
import Worker from './components/Worker';

function App() {
  return(
    <div>
      <Router>
          <Route exact path="/" component={Home}/>
          <Route path="/login" component={Login}/>
          <Route path="/admin" component={Admin}/>
          <Route path="/worker" component={Worker}/>
          <Route path="/customer" component={Customer}/>
      </Router>      
    </div>
  )
}

export default App;
