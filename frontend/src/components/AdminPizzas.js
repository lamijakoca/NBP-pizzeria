import React, { useEffect, useState } from 'react';
import {Table, Input, Button, message } from 'antd';
import axios from 'axios';
import database from '../utils'
import logo from '../assets/logo.png'
import './styles/adminPage.css'

function AdminPizzas(){
    const [pizzas, setPizzas] = useState([]);
    const [token, setToken] = useState("");
    const [id, setId ] = useState();

    const deletePizza = async (id) => {
        if(token){
            await axios.delete(`${database}/api/pizza/${id}`,{
                headers: {"Authorization" : token}
            })
            message.success("Successfully deleted!");
        }
    }

    const select = (e) => {setId(e.target.value)};

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
        <div className="divAdminovihPica">
            <img src={logo} alt="Pizzeria"/>
            <h2 className="pizzaH2">You can manage with pizzas here</h2>
            <Input
            value={id}
            onChange={select}
            style={{width:"250px", display:"block", margin:"0 auto"}}
            className="deleteById"
            placeholder="Insert id of pizza you want to delete"/>
            
            <Button 
            className="deletePizza"
            style={{display:"block", margin: "auto", top: "2px"}}
            type="default"
            htmlType="submit"
            onClick={() => {deletePizza(id)}}
            >
                Delete
            </Button>
            <Table
                rowKey="id"
                className="tablePizzas"
                columns={columns}
                dataSource={pizzas}
                pagination={{ pageSize: 6 }}>

            </Table>
        </div>
    )
}

export default AdminPizzas;