import React, { useState } from "react";
import { Form, Input, Button } from "antd";
import { useHistory } from "react-router-dom";
import { Upload, message } from "antd";
import { InboxOutlined } from '@ant-design/icons';
import axios from "axios";
import database from "../utils";

function AddPizza() {
  const history = useHistory();
  
  const {Dragger} = Upload;

  const [name, setName] = useState("");
  const [image, setImage] = useState("capricciosa");
  const [isPost, setIsPost] = useState(false);

  // if(isPost){history.push("/worker");}

  const createCard = () => {
    const token = localStorage.getItem("token");
    if (token) {
      const newPizza = {name, image};
      axios.post(`${database}/api/pizza`, newPizza, {
        headers: { "Authorization": token },
      });
      setIsPost(true)
    }
  };

  return (
    <div>
      <h2>New Pizza</h2>
      <h3>Title / Name of Pizza</h3>
      <Form onFinish={createCard}>
        <Input
          className="inputTitle"
          onChange={(e) => setName(e.target.value)}
        />

        <Button
          type="default"
          htmlType="submit"
          className="saveBtn"
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