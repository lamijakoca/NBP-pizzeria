import React from 'react';
import {useHistory} from 'react-router-dom';
import "./styles/adminPage.css";
import logo from '../assets/logo.png';

function Admin(){
    const history = useHistory();

    return(
        <div className="mainAdmin">
            <img src={logo} alt="Pizzeria"/>
            <button className="ingredients" onClick={()=>history.push('/ingredients')}>
                Ingredients
            </button>
            <button className="pizzas" onClick={() => history.push('/admin-pizzas')}>
                Pizzas
            </button>
            <button className="turnover">
                Turnover
            </button>
        </div>
    )
}

export default Admin;