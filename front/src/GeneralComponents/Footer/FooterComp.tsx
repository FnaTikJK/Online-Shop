import React from 'react';
import {Outlet, useNavigate} from 'react-router-dom'
import {Radio} from "antd";
import "./FooterComp.css"

const FooterComp = () => {
    const navigate = useNavigate();

    return (
        <>
            <Outlet />

            <footer>
                <Radio.Group defaultValue={"a"} size={"large"} style={{width:"100%"}}>
                    <Radio.Button value={"a"} onClick={() => navigate("/")}>Главная</Radio.Button>
                    <Radio.Button value={"b"} onClick={() => navigate("/Basket")}>Корзина</Radio.Button>
                    <Radio.Button value={"c"} onClick={() => navigate("/Favorites")}>Избранное</Radio.Button>
                    <Radio.Button value={"d"} onClick={() => navigate("/Profile")}>Аккаунт</Radio.Button>
                </Radio.Group>
            </footer>
        </>
    );
};

export default FooterComp;