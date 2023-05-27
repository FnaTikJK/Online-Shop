import React from 'react';
import ProductBasketManagerComp from "../../../GeneralComponents/ProductBasketManager/ProductBasketManagerComp";
import ProductFavoriteComp from "../../../GeneralComponents/ProductFavoriteComp/ProductFavoriteComp";
import styles from "./BasketItemCard.module.css"
import {BasketItemDTO} from "../../../APIHelper/Requesters/BasketRequester";
import {urlNoImage} from "../../../CommonResources";

type Props ={
    item: BasketItemDTO,
    summary: number,
    setSummary: React.Dispatch<React.SetStateAction<number>>
}

const SetSummaryFunc = (price: number, summary: number, setSummary: React.Dispatch<React.SetStateAction<number>>) => {
    return (delta: number) => {
        setSummary(summary + delta * price);
    }
}

const BasketItemCard = ({item, summary, setSummary}: Props) => {
    const url = "Products/" + item.product.id;

    return (
        <div className={styles.DivMain}>
            <div className={styles.DivSubName}>
                <a href={url}>
                    <img className={styles.Img} alt={item.product.name}
                        src={urlNoImage}/></a>
                <div>
                    <a href={url}><p className={styles.ProductName}>{item.product.name}</p></a>
                    <h3 className={styles.Price}>{item.product.price} ₽</h3>
                    <ProductBasketManagerComp
                        id={item.product.id} initCount={item.count}
                        setSummaryFunc={SetSummaryFunc(item.product.price, summary, setSummary)}/>
                    <ProductFavoriteComp id={item.product.id} initIsFavorited={false} />
                </div>
            </div>
            <hr className={styles.Separator}/>
        </div>
    );
};

export default BasketItemCard;