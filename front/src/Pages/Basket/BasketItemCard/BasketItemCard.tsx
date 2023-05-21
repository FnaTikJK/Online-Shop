import React from 'react';
import ProductBasketManagerComp from "../ProductCard/ProductBasketManager/ProductBasketManagerComp";
import ProductFavoriteComp from "../ProductCard/Favorite/ProductFavoriteComp";
import "./BasketItemCard.css";
import {BasketItemDTO} from "../../APIHelper/Requesters/BasketRequester";

type Props ={
    item: BasketItemDTO,
}

const BasketItemCard = ({item}: Props) => {
    const urlNoImage = "https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png";

    return (
        <div className={"div-Main"}>
            <div className={"div-Submain"}>
                <img alt={item.product.name}
                     src={urlNoImage}/>
                <div>
                    <p>{item.product.name}</p>
                    <h3>{item.product.price} ₽</h3>
                    <ProductBasketManagerComp id={item.product.id} initCount={item.count} />
                    <ProductFavoriteComp id={item.product.id} initIsFavorited={false} />
                </div>
            </div>
            <hr/>
        </div>
    );
};

export default BasketItemCard;