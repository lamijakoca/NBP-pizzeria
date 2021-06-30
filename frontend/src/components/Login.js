import React, { useState } from 'react';
import { Form, Input, Button } from 'antd';
import "antd/dist/antd.css";
import "./styles/login.css";
import logo from '../assets/logo.png'

function Login(){
    const [user, setUser] = useState("employee");
    //const [form] = Form.useForm();
    const onTypeChange = (value) => {
        if(value == "customer"){
            setUser("customer");
        }
        else setUser("employee");
    }
    return(
        <div className="loginDiv">
            <img src={logo} className="logo" alt="pizzeria"/>
            <Form className="formDiv">
                <Form.Item 
                label="Username" 
                name="username" 
                rules={[{required: true, message: "Please input your username!"}]}
                >
                    <Input/>
                </Form.Item>

                <Form.Item 
                label="Password" 
                name="password" 
                rules={[{required: true, min: 8 ,message:"Please input your password!"}]}
                >
                    <Input.Password/>
                </Form.Item>

                <Button 
                className="submitButton"
                type="primary" 
                htmlType="submit">
                    Submit
                </Button>
                <p className="regPlease">If you don't have an account, please Register.</p>
            </Form>
        </div>
    )
}

export default Login;