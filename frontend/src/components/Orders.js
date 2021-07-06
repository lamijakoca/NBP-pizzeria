import React, {useEffect, useState} from 'react';
import axios from 'axios';
import database from '../utils'
import {Card, Button, message} from 'antd'
import './styles/orders.css'
import logo from '../assets/logo.png'

function Orders(){
    const [order, setOrder] = useState([]);
    const [token, setToken] = useState();

    const getOrders = async(token) => {
        await axios.get(`${database}/api/orders`, {
            headers: {"Authorization" : token}
        })
        .then((res) => {
            setOrder(res.data);
        })
    }

    const declineOrder = async(id) => {
        if(token){
            await axios.delete(`${database}/api/orders/${id}`, {
                headers: {"Authorization" : token}
            })
        }
    }

    useEffect(() => {
        const token = localStorage.getItem("token");
        setToken(token);
        if(token){
            getOrders(token);
        }
    })

    return(
        <div className="orderMain">
            <img src={logo} alt="pizzeria"/>
            {
                order.map((o) => (
                    <Card 
                    className="orderCard"
                    key={o.id} 
                    title={`Order Number: ${o.id}`}
                    >
                        <p>Pizza</p>
                        <p>{o.price}</p>
                        <p>{o.size}</p>
                        <div className="orderFooter">
                            <Button 
                            className="AcceptBtn"
                            onClick={() => {
                                declineOrder(o.id);
                                message.success("Pizza is sold!")
                            }}
                            >
                                Accept
                            </Button>
                            <Button 
                            type="danger" 
                            className="DeclineBtn"
                            onClick={() => {
                                declineOrder(o.id)
                                message.info("Successfully Declined!");
                            }}
                            >
                                Decline
                            </Button>
                        </div>
                    </Card>
                ))
            }
        </div>
    )
}

export default Orders;