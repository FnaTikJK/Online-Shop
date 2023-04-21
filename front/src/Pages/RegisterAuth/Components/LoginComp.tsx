import React, {useState} from 'react';
import {Button, Input} from "antd";
import {AccountsRequester} from "../../../APIHelper/Requesters/AccountsRequester";

const LoginComp = () => {
    const [login, setLogin] = useState<string>('');
    const [password, setPassword] = useState<string>('');

    return (
        <div>
            <Input placeholder={'Логин'} onChange={event => setLogin(event.target.value)}/>
            <Input placeholder={'Пароль'} onChange={event => setPassword(event.target.value)}/>
            <Button type={"primary"} value={'Войти'} onClick={() => Login()}>
                Войти
            </Button>
        </div>
    );

    function Login(){
        AccountsRequester.Login({ login: login, password: password });
    }
};

export default LoginComp;