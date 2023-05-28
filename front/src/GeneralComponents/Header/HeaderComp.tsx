import React, {useContext, useEffect, useState} from 'react';
import {Outlet, useNavigate} from "react-router-dom";
import {Button} from "antd";
import Search from "antd/lib/input/Search";
import styles from "./HeaderComp.module.css";
import {HeartOutlined, ShoppingCartOutlined, UserOutlined} from "@ant-design/icons";
import {BasketCountContext, FavoritesContext} from "../../CommonResources";
import {FavoriteRequester} from "../../APIHelper/Requesters/FavoriteRequester";
import {BasketRequester} from "../../APIHelper/Requesters/BasketRequester";
import {AxiosError} from "axios";
import SearchComp from "./SearchComp/SearchComp";
import NavigationComp from "./NavigationComp/NavigationComp";



const HeaderComp = () => {
    return (
        <>
            <div className={styles.Mock}/>

            <header className={styles.Header}>
                <div className={styles.Logo}><a href={"/"}>Logo</a></div>
                <SearchComp />
                <NavigationComp />
            </header>

            <Outlet />
        </>
    );
};

export default HeaderComp;