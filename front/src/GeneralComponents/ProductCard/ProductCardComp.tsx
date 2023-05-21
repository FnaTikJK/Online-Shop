import React from 'react';
import ProductFavoriteComp from "../ProductFavoriteComp/ProductFavoriteComp";
import ProductBasketManagerComp from "../ProductBasketManager/ProductBasketManagerComp";
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";
import "./ProductCardComp.css"

type Props ={
    product: ProductShortDTO,
    initIsFavorited: boolean,
    initCount: number,
}

const ProductCardComp = ({product, initIsFavorited, initCount}: Props) => {
    const urlNoImage = "https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png";

    return (
        <div className={"Card-container"}>
            <div className={"Img-container"}>
                <img src={urlNoImage} className={"Img"}/>
            </div>
            <div className={"Favorite-Button"}><ProductFavoriteComp id={product.id} initIsFavorited={true} /></div>
            <p>{product.name}</p>
            <h4>{product.price} ₽</h4>
            <ProductBasketManagerComp id={product.id} initCount={0} />
        </div>
    );
};

export default ProductCardComp;