import React, { useEffect, useState } from 'react';
import {Table } from 'antd';
import axios from 'axios';
import database from '../utils'
import logo from '../assets/logo.png'
import './styles/adminPage.css'

function AdminPizzas(){
    const [pizzas, setPizzas] = useState([]);
    const [token, setToken] = useState("");

    const getPizzas = async(token) => {
        axios.get(`${database}/api/pizza`, {
            headers: {"Authorization" : token}
        })
            .then((res) => setPizzas(res.data))
    }

    useEffect(() => {
        const token = localStorage.getItem("token");
        setToken(token);
        if(token){
            getPizzas(token);
        }
    }, []);

    const columns = [
        {
            title: 'Id',
            dataIndex: 'id'
        },
        {
            title: 'Name',
            dataIndex: 'name'
        },
        {
            title : 'Image',
            dataIndex: 'image'
        }
    ]
    return(
        <div>
            <img src={logo} alt="Pizzeria"/>
            <h2 className="pizzaH2">You can manage with pizzas here</h2>
            <Table
            className="tablePizzas"
            columns={columns}
            dataSource={pizzas}
            pagination={{ pageSize: 6 }}>

            </Table>
        </div>
    )
}

export default AdminPizzas;