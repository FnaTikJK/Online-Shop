import React from 'react';
import ProductBasketManagerComp from "../../../GeneralComponents/ProductBasketManager/ProductBasketManagerComp";
import ProductFavoriteComp from "../../../GeneralComponents/ProductFavoriteComp/ProductFavoriteComp";
import styles from "./BasketItemCard.module.css"
import {BasketItemDTO} from "../../../APIHelper/Requesters/BasketRequester";

type Props ={
    item: BasketItemDTO,
}

const BasketItemCard = ({item}: Props) => {
    const urlNoImage = "https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png";

    return (
        <div className={styles.DivMain}>
            <div className={styles.DivSubName}>
                <img className={styles.Img} alt={item.product.name}
                     src={urlNoImage}/>
                <div>
                    <p className={styles.ProductName}>{item.product.name}</p>
                    <h3 className={styles.Price}>{item.product.price} ₽</h3>
                    <ProductBasketManagerComp id={item.product.id} initCount={item.count} />
                    <ProductFavoriteComp id={item.product.id} initIsFavorited={false} />
                </div>
            </div>
            <hr className={styles.Separator}/>
        </div>
    );
};

export default BasketItemCard;