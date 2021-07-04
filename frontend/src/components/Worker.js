import React, { useEffect, useState } from 'react';
import * as images from '../assets/assetsJS'
import {useHistory} from 'react-router-dom';
import logo from '../assets/logo.png';
import { Card, Button } from 'antd';
import "./styles/workerPage.css";
import database from '../utils';
import axios from 'axios';

function Worker(){
    const history = useHistory();

    const [size, setSize] = useState("Medium");
    const [pizza, setPizza] = useState([]);
    const [token, setToken] = useState("");

    const getPizzas = async(token) => {
        const res = await axios.get(`${database}/api/pizza`, {
            headers: {"Authorization": token}
            
        })
        setPizza(res.data);
        //console.log(res.data[0]);
    }
    const handleChange = (value) =>{
        setSize(value);
    }

    useEffect(() => {
        const token = localStorage.getItem("token");
        setToken(token);
        if(token){
            getPizzas(token);
        }
    }, [])

    return(
        <div className="workerMain">
            <img src={logo} alt="Pizzeria"/>
            <Button 
            type="default" 
            className="addPizza" 
            onClick={() => history.push('/new')}
            >
                Add Pizza
            </Button>
            {
                pizza.map((p) => (
                    <div key={p.id}>
                        <Card title={p.name} className="cards">
                            <img className="pizzaImg" src={images[p.image]} alt="Pizza"/>
                            {/* {console.log(p.image)} */}
                            <p>Ingredients</p>
                            <div className="footer">
                                <select onChange={handleChange} className="selectSize">
                                    <option value="small">Small</option>
                                    <option value="medium">Medium</option>
                                    <option value="big">Big</option>
                                </select>
                                <Button type="default" className="addToCart">
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

export default Worker;