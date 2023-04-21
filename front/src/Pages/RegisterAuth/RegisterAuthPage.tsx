import React, {FC, useState} from 'react';
import RegisterComp from "./Components/RegisterComp";
import LoginComp from "./Components/LoginComp";
import {Radio} from "antd";

export interface RegisterAuthProps {
    width: string;
    height: string;
}

const RegisterAuthPage: FC = () => {
    const [pageState, setPageState] = useState<"Registration" | "Login">("Login");

        return (
            <div>
                <Radio.Group defaultValue={"a"}>
                    <Radio.Button value={"a"} onClick={() => setPageState("Login")}>Вход</Radio.Button>
                    <Radio.Button value={"b"} onClick={() => setPageState("Registration")}>Регистрация</Radio.Button>
                </Radio.Group>
                {pageState === "Login" ? <LoginComp></LoginComp>
                    : <RegisterComp></RegisterComp>}
            </div>
        );
};

export default RegisterAuthPage;