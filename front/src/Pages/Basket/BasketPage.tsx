import React, {useEffect, useState} from 'react';
import {BasketItemDTO, BasketRequester} from "../../APIHelper/Requesters/BasketRequester";
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";

const BasketPage = () => {
    const [items, setItems] = useState<BasketItemDTO[] | null>(null);

    useEffect(() => {
        SetItemsAsync();
    }, []);

    return (
        <>
            <h1>Basket</h1>
            {items === null ?
                <>
                    Loading...
                </>
                :
                    items.length === 0 ?
                    <h2>Корзина пуста</h2>
                    :
                    items.map((item) =>
                    <>
                        <ProductCardComp product={item.product} initIsFavorited={false} initCount={item.count} />
                    </>)
            }
        </>
    );

    async function SetItemsAsync(){
        try {
            let response = await BasketRequester.GetAllItemsAsync();
            setItems(response.data);
        }
        catch (e) {
            alert(e);
        }
    }
};

export default BasketPage;