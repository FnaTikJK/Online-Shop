import React, {useEffect, useState} from 'react';
import {useParams} from "react-router";
import {ProductDto, ProductRequester} from "../../APIHelper/Requesters/ProductRequester";
import {GUID} from "../../Infrastructure/Guid";
import styles from "./ProductPage.module.css";
import {urlNoImage} from "../../CommonResources";
import ProductBasketManagerComp from "../../GeneralComponents/ProductBasketManager/ProductBasketManagerComp";
import ProductFavoriteComp from "../../GeneralComponents/ProductFavoriteComp/ProductFavoriteComp";
import {Button} from "antd";

async function GetProductAsync(id: GUID): Promise<ProductDto | undefined> {
    try {
        let response = await ProductRequester.GetProductByIdAsync(id, true);
        return response.data
    }
    catch (e) {
        try {
            let response = await ProductRequester.GetProductByIdAsync(id);
            return response.data
        }
        catch (e){
            alert(e);
        }
    }
}

type Params = {
    id: GUID
}

const ProductPage = () => {
    const { id } = useParams<Params>();
    const [product, setProduct] = useState<ProductDto | null | undefined>(null)

    useEffect(() => {(async () => {
        if (id !== undefined) {
            setProduct(await GetProductAsync(id));
        }
    })()}, [])

    if (id === undefined || product === undefined)
        return (<div> <h1>404 Not Found</h1> </div>)

    if (product === null)
        return (<div>Загрузка...</div>)

    return (
        <div className={styles.DivMain}>
            <div className={styles.DivImgContainer}>
                <img src={product.image as string ?? urlNoImage} className={styles.Img}/>
            </div>

            <div className={styles.DivInfo}>
                <h2>{product.name}</h2>
                {product.categories.map(c => <Button>{c.name}</Button>)}
                <h3>{product.price} ₽</h3>
                <ProductBasketManagerComp id={product.id} initCount={product.countInBasket} />
                <ProductFavoriteComp id={product.id} initIsFavorited={product.isFavorited} />
                <h4>Описание</h4>
                {product.description}
            </div>
        </div>
    );
};

export default ProductPage;