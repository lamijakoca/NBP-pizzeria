import React, { useEffect, useState } from 'react';
import * as images from '../assets/assetsJS'
import {useHistory} from 'react-router-dom';
import logo from '../assets/logo.png';
import { Card, Button, message } from 'antd';
import "./styles/customerPage.css";
import database from '../utils';
import axios from 'axios';

function Customer(){
    const history = useHistory();

    const [size, setSize] = useState("");
    const [price, setPrice] = useState();
    const [date, setDate] = useState();
    const [pizza, setPizza] = useState([]);
    const [id, setId] = useState(10);
    const [pizzaActual, setPizzaActual] = useState();
    const [token, setToken] = useState("");

    var today = new Date(),
    todayDate = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();


    const getPizzas = async(token) => {
        const res = await axios.get(`${database}/api/pizza`, {
            headers: {"Authorization": token}
        })
        setPizza(res.data);
    }

    const handleChange = (value) =>{
        setSize(value);
        console.log(size);
    }

    useEffect(() => {
        const token = localStorage.getItem("token");
        setToken(token);
        if(token){
            getPizzas(token);
        }
    }, [])

    const addToCart = async(token) =>{
        const pizzaActuals = {size, price, date}
        console.log(size, price, date);
        await axios.post(`${database}/api/orders`, pizzaActuals,{
            headers: {"Authorization" : token}
        })
        .then((res) => {
            setPizzaActual(res.data);
            message.success("Porudzbina uspesno izvrsena!");
        })  
    }

    
    return(
        <div className="customerMain">
            <img src={logo} alt="Pizzeria"/>
            {
                pizza.map((p) => (
                    <div key={p.id}>
                        <Card title={p.name} className="cards">
                            <img className="pizzaImg" src={images[p.image]} alt="Pizza"/>
                            <p style={{marginLeft:"83%", fontWeight:"bold"}}>Ingredients</p>
                            <ul title="Ingredients">
                                <li>meso</li>
                                <li>paradajz sos</li>
                                <li>trapist</li>
                                <li>origano</li>
                            </ul>
                            <div className="footer">
                                <select onChange={(event) => {
                                    setSize(event.target.value)
                                    if(size === "small"){
                                        setPrice(250);
                                    }
                                    else if (size === "medium"){
                                        setPrice(300);
                                    }
                                    else setPrice(350);
                                    }} 
                                    className="selectSize">
                                    <option value="small">Small</option>
                                    <option value="medium">Medium</option>
                                    <option value="big">Big</option>
                                </select>
                                <Button 
                                type="default" 
                                className="addToCart"
                                onClick={() => {
                                    setDate(todayDate);
                                    addToCart(token)
                                    }}>
                                    Add to Cart
                                </Button>
                            </div>
                        </Card>
                    </div>
                ))
            }
        </div>
    )
}

export default Customer;