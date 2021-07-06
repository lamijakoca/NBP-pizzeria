import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Form, Input, Button, message } from "antd";
import logo from "../assets/logo.png";
import backend from "../utils";
import axios from "axios";
import "antd/dist/antd.css";
import "./styles/login.css";

function Login() {
  const history = useHistory();
  const [type, setType] = useState("Select");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [isLogin, setIsLogin] = useState(false);

  const onTypeChange = (event) => {
    setType(event.target.value);
  };

  const howToPush = () =>{
    if (type === "employee"){
      history.push('/worker')
    }
    else if (type === "admin"){
      history.push('/admin')
    }
  }
  const loginSubmit = async () => {
    const User = { username, password };
    if (type === "employee" || type === "admin") {
      await axios.post(`${backend}/api/auth/login`, User)
          .then((res) => {
            const token = res.data;
            localStorage.setItem("token", token);
            setIsLogin(true);
      }, howToPush());
    } else if (type === "customer") {
      await axios.post(`${backend}/api/auth/login/customer`, User)
            .then((res) => {
            const token = res.data;
            localStorage.setItem("token", token);
            setIsLogin(true);
      }, history.push('/customer'));
    }
  };

  // if (isLogin === true && type === "employee") {
  //   history.push("/worker");
  //   console.log("okej tu si");
  //   message.success("You are logged in", 2);
  // } else if (isLogin === true && type === "customer") {
  //   history.push("/customer");
  //   console.log("Welcome customer!");
  // }

  return (
    <div className="loginDiv">
      <img src={logo} className="logo" alt="pizzeria" />

      <Form className="formDiv" onFinish={loginSubmit}>
        <Form.Item
          label="Username"
          name="username"
          rules={[{ required: true, message: "Please input your username!" }]}
        >
          <Input onChange={(e) => setUsername(e.target.value)} />
        </Form.Item>

        <Form.Item
          label="Password"
          name="password"
          rules={[
            { required: true, min: 8, message: "Please input your password!" },
          ]}
        >
          <Input.Password onChange={(e) => setPassword(e.target.value)} />
        </Form.Item>

        <Form.Item name="type" label="Type" rules={[{ required: true }]}>
          {/* antd select ne radi  */}
          <select onChange={onTypeChange} className="selectOption" value={type}>
            <option value="Select">Select</option>
            <option value="customer">Customer</option>
            <option value="admin">Admin</option>
            <option value="employee">Employee</option>
          </select>
        </Form.Item>

        <Button className="submitButton" type="primary" htmlType="submit">
          Submit
        </Button>

        <p className="regPlease">
          If you don't have an account, please Register.
        </p>
      </Form>
    </div>
  );
}

export default Login;
