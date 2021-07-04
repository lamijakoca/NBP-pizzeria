import React from 'react';
import {BrowserRouter as Router, Route} from 'react-router-dom';
import AddPizza from './components/AddPizza';
import Admin from './components/Admin';
import AdminPizzas from './components/AdminPizzas';
import Customer from './components/Customer';
import Home from './components/Home';
import Ingredients from './components/Ingredients';
import Login from './components/Login';
import Worker from './components/Worker';

function App() {
  return(
    <div>
      <Router>
          <Route exact path="/" component={Login}/>
          <Route path="/home" component={Home}/>
          <Route path="/admin" component={Admin}/>
          <Route path="/worker" component={Worker}/>
          <Route path="/customer" component={Customer}/>
          <Route path="/new" component={AddPizza}/>
          <Route path="/ingredients" component={Ingredients}/>
          <Route path="/admin-pizzas" component={AdminPizzas}/>
      </Router>      
    </div>
  )
}

export default App;
