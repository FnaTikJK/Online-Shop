import React from 'react';
import ProductFavoriteComp from "../ProductFavoriteComp/ProductFavoriteComp";
import ProductBasketManagerComp from "../ProductBasketManager/ProductBasketManagerComp";
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";
import styles from "./ProductCardComp.module.css"
import {urlNoImage} from "../../Constants";

type Props ={
    product: ProductShortDTO,
    initIsFavorited: boolean,
    initCount: number,
}

const ProductCardComp = ({product, initIsFavorited, initCount}: Props) => {
    return (
        <div className={styles.CardContainer}>
            <div className={styles.ImgContainer}>
                <img src={urlNoImage} className={styles.Img}/>
            </div>
            <div className={styles.FavoriteButton}>
                <ProductFavoriteComp id={product.id} initIsFavorited={initIsFavorited} />
            </div>
            <p className={styles.Name}>{product.name}</p>
            <h4 className={styles.Price}>{product.price} ₽</h4>
            <ProductBasketManagerComp id={product.id} initCount={initCount} />
        </div>
    );
};

export default ProductCardComp;