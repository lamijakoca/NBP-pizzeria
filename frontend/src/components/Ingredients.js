import React, { useEffect, useState } from 'react';
import  {Table, Input, Button, message} from 'antd';
import axios from 'axios';
import database from '../utils'
import './styles/adminPage.css';
import logo from '../assets/logo.png'

function Ingredients(){
    const [ingredients, setIngredients] = useState([]);
    const [id, setId] = useState();
    const [token, setToken] = useState("");
    const [name, setName] = useState("");

    const getIngredients = async(token) => {
        axios.get(`${database}/api/ingredient`, {
            headers: {"Authorization": token}
        })
        .then((res) =>{ 
            console.log(res.data);
            setIngredients(res.data);
        })
    }
    
    const deleteIngredient = async(id) =>{
        if(token){
            await axios.delete(`${database}/api/ingredient/${id}`,{
                headers: {"Authorization" : token}
            })
            message.success("Successfully deleted!");
            getIngredients(token);
        }
    }

    useEffect(() => {
        const token = localStorage.getItem("token");
        setToken(token);
        if(token){
            getIngredients(token);
        }
    }, [])

    const columns=[
        {
            title: 'Id',
            dataIndex: 'id'
        },
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name'
        },
        {
            title: 'Orgin',
            dataIndex: 'origin'
        },
        {
            title: 'KCAL',
            dataIndex: 'kcal'
        },
        {
            title: 'Quantity',
            dataIndex: 'quantity'
        },
        {
            title: 'Price',
            dataIndex: 'price'
        }
    ]
    return (
        <div>
            <img src={logo} alt="Pizzeria"/>
            <h2 className="ingredientH2">You can manage with ingredients here</h2>
            <Input 
            style={{width:"250px", display:"block", margin:"0 auto"}}
            onChange={(e) => {setId(e.target.value)}}
            placeholder="Insert id of Ingredient you want to delete"/>
            
            <Button 
            style={{width:"100px", display:"block", margin:"0 auto", top:"2px"}}
            htmltype="submit" 
            onClick={() => {deleteIngredient(id)}}>
                Delete
            </Button>

            <Table 
            className="nurliTabela"
            columns={columns} 
            dataSource={ingredients}
            pagination={{ pageSize: 6 }}>
        </Table>

        </div>
        
    )
}

export default Ingredients;