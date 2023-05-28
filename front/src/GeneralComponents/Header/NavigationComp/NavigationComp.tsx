import React, {useContext, useEffect} from 'react';
import styles from "../HeaderComp.module.css";
import {HeartOutlined, ShoppingCartOutlined, UserOutlined} from "@ant-design/icons";
import {useNavigate} from "react-router-dom";
import {BasketCountContext, FavoritesContext} from "../../../CommonResources";
import {FavoriteRequester} from "../../../APIHelper/Requesters/FavoriteRequester";
import {BasketRequester} from "../../../APIHelper/Requesters/BasketRequester";

async function GetFavoritesCountAsync(): Promise<number | undefined>{
    try{
        let response = await FavoriteRequester.GetFavoritesCountAsync();
        return response.data;
    }
    catch (e: any){
        if (e.response.status !== 401 || e.response.status !== 403)
            alert(e);
    }
}

async function GetBasketCountAsync(): Promise<number | undefined>{
    try{
        let response = await BasketRequester.GetItemsCountAsync();
        return response.data;
    }
    catch (e: any){
        if (e.response.status !== 401 || e.response.status !== 403)
            alert(e);
    }
}

const NavigationComp = () => {
    const favoriteType = useContext(FavoritesContext);
    const basketType = useContext(BasketCountContext);

    useEffect(() => {(async () => {
        let favoritesCount = await GetFavoritesCountAsync();
        let basketCount = await GetBasketCountAsync();
        if (favoriteType !== null && favoritesCount !== undefined)
            favoriteType.setFavorites(favoritesCount);
        if (basketType !== null && basketCount !== undefined)
            basketType.setCountInBasket(basketCount);
    })()},[])
    const navigate = useNavigate();

    return (
        <div className={styles.Navigation}>
            <UserOutlined style={{ fontSize: '25px' }} onClick={() => {navigate("Profile")}}/>
            <HeartOutlined
                style={{  fontSize: '25px', marginLeft:"10px" }} onClick={() => {navigate("Favorites")}}/>
            <div style={{ display: "inline-block" }}>{favoriteType?.favorites}</div>
            <ShoppingCartOutlined
                style={{ fontSize: '25px', marginLeft:"10px" }} onClick={() => {navigate("Basket")}}/>
            <div style={{display:"inline-block"}}>{basketType?.countInBasket}</div>
        </div>
    );
};

export default NavigationComp;