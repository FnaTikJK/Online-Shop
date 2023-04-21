import React, {FC, useState} from 'react';
import { Button, DatePicker, Input } from 'antd';
import {AccountsRequester} from "../../../APIHelper/Requesters/AccountsRequester";

const RegisterComp: FC = () => {
    const [login, setLogin] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [secondName, setSecondName] = useState<string>('');
    const [firstName, setFirstName] = useState<string>('');
    const [thirdName, setThirdName] = useState<string>('');
    const birthDateFormat = "YYYY-MM-DD";
    const [birthDate, setBirthDate] = useState<string | null>('2000-01-01');

    return (
        <div>
            <Input placeholder={"Логин"} onChange={event => setLogin(event.target.value)}/>
            <Input placeholder={"Пароль"} onChange={event => setPassword(event.target.value)}/>
            <Input placeholder={"Фамилия"} onChange={event => setSecondName(event.target.value)}/>
            <Input placeholder={"Имя"} onChange={event => setFirstName(event.target.value)}/>
            <Input placeholder={"Отчество"} onChange={event => setThirdName(event.target.value)}/>
            <DatePicker placeholder={"Дата рождения"} format={birthDateFormat}
                        onChange={date => date !== null ? setBirthDate(date.format(birthDateFormat)) : date}/>
            <Button type={"primary"} onClick={() => Register()}>
                Зарегистрироваться
            </Button>
        </div>
    );

    function Register(){
        AccountsRequester.Register({
            login: login,
            password: password,
            secondName: secondName,
            firstName: firstName,
            thirdName: thirdName === "" ? null : thirdName,
            birthDate: birthDate,
        });
    }
};

export default RegisterComp;