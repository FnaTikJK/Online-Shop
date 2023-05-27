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
    const url = "Products/" + product.id;

    return (
        <div className={styles.CardContainer}>
            <div className={styles.ImgContainer}>
                <a href={url}><img src={urlNoImage} className={styles.Img}/></a>
            </div>
            <div className={styles.FavoriteButton}>
                <ProductFavoriteComp id={product.id} initIsFavorited={initIsFavorited} />
            </div>
            <a href={url}><p className={styles.Name}>{product.name}</p></a>
            <h4 className={styles.Price}>{product.price} ₽</h4>
            <ProductBasketManagerComp id={product.id} initCount={initCount} />
        </div>
    );
};

export default ProductCardComp;