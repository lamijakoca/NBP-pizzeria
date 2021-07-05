import React, { useState } from "react";
import { Form, Input, Button, message } from "antd";
import { useHistory } from "react-router-dom";
import axios from "axios";
import database from "../utils";
import './styles/addPizzaPage.css'
import logo from '../assets/logo.png'

function AddPizza() {
  const history = useHistory();

  const [name, setName] = useState("");
  const [image, setImage] = useState("");

  const createCard = () => {
    const token = localStorage.getItem("token");
    if (token) {
      const newPizza = {name, image};
      axios.post(`${database}/api/pizza`, newPizza, {
        headers: { "Authorization": token },
      });
    }
  };

  return (
    <div className="newPizzaDiv">
      <img src={logo} alt="logo"/>
      <h2 className="addPizzaH2">Here you can add new pizza!</h2>
      <h4>Title / Name of Pizza</h4>
      
      <Form onFinish={createCard}>
        <Input
          className="inputTitle"
          onChange={(e) => setName(e.target.value)}
        />

        <input 
        onChange={(e)=>{
          var needSlice = e.target.value;
          var sliceNow = needSlice.slice(12, needSlice.length - 4);
          setImage(sliceNow)
        }}
        type="file" 
        accept="image/png, image/jpeg, image/jpg"
        className="imageInput"
        />
        
        <Button
          type="primary"
          htmlType="submit"
          className="saveBtn"
          onClick={() => {
            message.success("Successfully saved!")
          }}
        >
          Save
        </Button>

        <Button 
        type="default" 
        className="cancelBtn" 
        onClick={() => history.push('/worker')}>
          Cancel
        </Button>
      </Form>
    </div>
  );
}

export default AddPizza;