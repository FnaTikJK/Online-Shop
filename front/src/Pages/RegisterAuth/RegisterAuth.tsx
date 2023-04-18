import React, {FC, ReactChildren, useState} from 'react';
import axios from "axios";
import {baseUrl} from "../../index";

export interface RegisterAuthProps {
    width: string;
    height: string;
    children: React.ReactChild | React.ReactNode;
}

const RegisterAuth: FC<RegisterAuthProps> = ({width, height, children}) => {
    const [login, setLogin] = useState('login')
    const [password, setPassword] = useState('password')

    return (
        <div>
            <input value={login} onChange={event => setLogin(event.target.value)}/>
            <input value={password} onChange={event => setPassword(event.target.value)}/>
            <button onClick={() => axios.post(baseUrl+'Values', {login: "1", password: "1"})
                .then(e => console.log(e.data))}>
            </button>
        </div>
    );
};

export default RegisterAuth;