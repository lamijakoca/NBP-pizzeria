import React, { useEffect, useState } from 'react';
import * as images from '../assets/assetsJS'
import {useHistory} from 'react-router-dom';
import logo from '../assets/logo.png';
import { Card, Button, message } from 'antd';
import {DeleteOutlined} from '@ant-design/icons';
import "./styles/workerPage.css";
import database from '../utils';
import axios from 'axios';

function Worker(){
    const history = useHistory();

    const [pizza, setPizza] = useState([]);
    const [token, setToken] = useState("");
  
    const getPizzas = async(token) => {
        const res = await axios.get(`${database}/api/pizza`, {
            headers: {"Authorization": token}    
        })
        setPizza(res.data);
        //console.log(res.data[0]);
    }

    const deletePizza = async (id) => {
        if(token){
            await axios.delete(`${database}/api/pizza/${id}`,{
                headers: {"Authorization" : token}
            })
            message.success("Successfully deleted!");
        }
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
                    <div key={p.name}>
                        <Card title={p.name} className="cards">
                            <img className="pizzaImg" src={images[p.image]} alt="Pizza"/>
                            {/* {console.log(p.image)} */}
                            <p style={{marginLeft:"83%", fontWeight:"bold"}}>Ingredients</p>
                            <ul title="Ingredients">
                                <li>meso</li>
                                <li>paradajz sos</li>
                                <li>trapist</li>
                                <li>origano</li>
                            </ul>
                            <div className="footer">
                                <Button 
                                className="deleteBtn"
                                onClick={() => {deletePizza(p.id)}}
                                >
                                    <DeleteOutlined />
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