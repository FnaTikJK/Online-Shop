import React, {useEffect, useState} from 'react';
import {useParams} from "react-router";
import {ProductDto, ProductRequester} from "../../APIHelper/Requesters/ProductRequester";
import {GUID} from "../../Infrastructure/Guid";
import styles from "./ProductPage.module.css";

async function GetProductAsync(id: GUID): Promise<ProductDto | undefined> {
    try {
        let response = await ProductRequester.GetProductByIdAsync(id);
        return response.data
    }
    catch (e) {

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
            <div className={styles.DivFullInfo}>
                {product.name}
            </div>
            <div className={styles.DivShortInfo}>

            </div>
        </div>
    );
};

export default ProductPage;