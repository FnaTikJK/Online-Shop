import React, {useState} from 'react';
import {Button, Input, Form} from "antd";
import {AccountsRequester} from "../../../APIHelper/Requesters/AccountsRequester";
import {useNavigate} from "react-router-dom";
import {AxiosResponse} from "axios/index";
import {ProfileDto, ProfilesRequester} from "../../../APIHelper/Requesters/ProfilesRequester";

const LoginComp = () => {
    const navigate = useNavigate();
    const [login, setLogin] = useState<string>('');
    const [password, setPassword] = useState<string>('');

    return (
        <>
            <Form autoComplete={"off"}>
                <Form.Item label="Логин" name="login" rules={[{ required: true }]}>
                    <Input onChange={event => setLogin(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Пароль" name="password" rules={[{ required: true }]}>
                    <Input onChange={event => setPassword(event.target.value)}/>
                </Form.Item>
                <Form.Item>
                    <Button type={"primary"} value={'Войти'} onClick={() => LoginAsync()}>
                        Войти
                    </Button>
                </Form.Item>
            </Form>
        </>
    );

    async function LoginAsync(){
        try {
            await AccountsRequester.LoginAsync({ login: login, password: password });
            navigate('/Profile');
        }
        catch (e: any){ // AxiosError
            alert(`Ошибка ${e.response.status}. ${e.response.text}`);
        }
    }
};

export default LoginComp;