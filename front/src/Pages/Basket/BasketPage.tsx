import React, {useEffect, useRef, useState} from 'react';
import {BasketItemDTO, BasketRequester} from "../../APIHelper/Requesters/BasketRequester";
import {NavigateFunction, useNavigate} from "react-router-dom";
import BasketItemCard from "./BasketItemCard/BasketItemCard";
import styles from "./BasketPage.module.css"
import {Button} from "antd";

async function GetItemsAsync(navigate: NavigateFunction): Promise<BasketItemDTO[] | undefined>{
    try {
        let response = await BasketRequester.GetAllItemsAsync();
        return response.data;
    }
    catch (e: any) {
        if (e.response.status === 401)
            navigate("/Auth");
        else
            alert(e);
    }
}

function DrawItems(items: BasketItemDTO[]): JSX.Element | JSX.Element[] {
    return items.length === 0 ?
        (<h2 className={styles.Centered}>Корзина пуста</h2>)
        :
        items.map((item) =>
            <BasketItemCard item={item} />);
}

const BasketPage = () => {
    const [items, setItems] = useState<BasketItemDTO[] | null>(null);
    const navigate = useNavigate();

    useEffect(() => { (async () => {
        let items = await GetItemsAsync(navigate);
        setItems(items ?? []);
    })()}, []);

    if (items === null)
        return (<><h1 className={styles.Centered}>Корзина</h1>
            <div className={styles.Centered}>Загрузка...</div></>);

    return (
        <>
            <h1 className={styles.Centered}>Корзина</h1>
            {DrawItems(items)}
            <div className={styles.DivSummary}>
                <h2 className={styles.Summary}>
                    Итого: {items
                        .map(i => i.product.price * i.count)
                        .reduce((total, value) => total + value)} ₽
                </h2>
            </div>
            <Button className={styles.OfferButton}>ОФОРМИТЬ ЗАКАЗ</Button>
        </>
    );
};

export default BasketPage;