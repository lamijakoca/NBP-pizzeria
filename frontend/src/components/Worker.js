import React from 'react';
import logo from '../assets/logo.png'
import "./styles/workerPage.css"

function Worker(){
    return(
        <div className="workerMain">
            <img src={logo} alt="Pizzeria"/>
            <h2>Worker Page</h2>
        </div>
    )
}

export default Worker;