import React, {FC, useState} from 'react';
import {Button, DatePicker, Form, Input} from 'antd';
import {AccountsRequester} from "../../../APIHelper/Requesters/AccountsRequester";
import {useNavigate} from "react-router-dom";

const RegisterComp: FC = () => {
    const [login, setLogin] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [secondName, setSecondName] = useState<string>('');
    const [firstName, setFirstName] = useState<string>('');
    const [thirdName, setThirdName] = useState<string>('');
    const birthDateFormat = "YYYY-MM-DD";
    const [birthDate, setBirthDate] = useState<string | null>('2000-01-01');
    const navigate = useNavigate();

    return (
        <>
            <Form autoComplete={"off"}>
                <Form.Item label="Логин" name="login" rules={[{ required: true }]}>
                    <Input onChange={event => setLogin(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Пароль" name="password" rules={[{ required: true }]}>
                    <Input onChange={event => setPassword(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Фамилия" name="secondName" rules={[{ required: true }]}>
                    <Input onChange={event => setSecondName(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Имя" name="firstName" rules={[{ required: true }]}>
                    <Input onChange={event => setFirstName(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Отчество" name="thirdName" rules={[{ required: false }]}>
                    <Input onChange={event => setThirdName(event.target.value)}/>
                </Form.Item>
                <Form.Item label="Дата рождение" name="birthdate" rules={[{ required: true }]}>
                    <DatePicker format={birthDateFormat}
                                onChange={date => date !== null ? setBirthDate(date.format(birthDateFormat)) : date}/>
                </Form.Item>
                <Form.Item>
                    <Button type={"primary"} value={'Войти'} onClick={() => RegisterAsync()}>
                        Регистрация
                    </Button>
                </Form.Item>
            </Form>
        </>
    );

    async function RegisterAsync(){
        try {
            await AccountsRequester.RegisterAsync({
                login: login,
                password: password,
                secondName: secondName,
                firstName: firstName,
                thirdName: thirdName === "" ? null : thirdName,
                birthDate: birthDate,
            });
            navigate('/Profile');
        }
        catch (e: any){ // AxiosError
            alert(`Ошибка ${e.response.status}. ${e.response.text}`);
        }
    }
};

export default RegisterComp;