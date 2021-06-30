import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Form, Input, Button, message } from 'antd';
import "antd/dist/antd.css";
import "./styles/login.css";
import logo from '../assets/logo.png'
import backend from '../utils'; 
import axios from 'axios';

function Login(){
    const history = useHistory();
    //const [user, setUser] = useState("employee");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [isLogin, setIsLogin] = useState(false);

    //const [form] = Form.useForm();
    // const onTypeChange = (value) => {
    //     if(value == "customer"){
    //         setUser("customer");
    //     }
    //     else setUser("employee");
    // }

    const loginSubmit = async () => {
        const User = {username, password};
        axios.post(`${backend}/api/auth/login`, User)
             .then((res) => {
                 const {token} = res.data;
                 localStorage.setItem("token", token);
                 setIsLogin(true);
             })
    }

    if (isLogin == true){
        history.push("/employee");
        console.log("okej tu si");
        message.success("You are logged in");
        setTimeout(function () {
            window.location.reload(1);
          }, 1500);
    }
    return(
        <div className="loginDiv">
            <img src={logo} className="logo" alt="pizzeria"/>
            <Form className="formDiv" onFinish={loginSubmit}>
                <Form.Item 
                label="Username" 
                name="username" 
                rules={[{required: true, message: "Please input your username!"}]}
                >
                    <Input onChange = {(e) => setUsername(e.target.value)}/>
                </Form.Item>

                <Form.Item 
                label="Password" 
                name="password" 
                rules={[{required: true, min: 8 ,message:"Please input your password!"}]}
                >
                    <Input.Password onChange = {(e) => setPassword(e.target.value)}/>
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