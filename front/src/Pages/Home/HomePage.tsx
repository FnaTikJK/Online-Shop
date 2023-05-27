import React, {useEffect, useState} from 'react';
import {ProfileDto, ProfilesRequester} from "../../APIHelper/Requesters/ProfilesRequester";
import {ProductDto, ProductRequester} from "../../APIHelper/Requesters/ProductRequester";
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";
import {AxiosResponse} from "axios";
import styles from "./HomePage.module.css"

async function GetProductsAsync(): Promise<ProductDto[] | undefined>{
    try {
        let response: AxiosResponse<ProductDto[]> = await ProductRequester.GetAllProducts();
        return response.data;
    }
    catch (e: any){ // AxiosError
        alert(`Ошибка ${e.response.status}. ${e.response.text}`);
    }
}

const HomePage = () => {
    const [products, setProducts] = useState<ProductDto[] | null>(null);

    useEffect(() => {(async () => {
        setProducts(await GetProductsAsync() ?? []);
    })()}, [])

    if (products === null)
        return (
            <div className={styles.DivMain}>
                Loading...
            </div>
        );

    return (
        <div className={styles.DivMain}>
            {products.map((p) =>
            <ProductCardComp product={p} initIsFavorited={false} initCount={0}/>
            )}
            <div className={styles.DivEnd}></div>
        </div>
    );


};

export default HomePage;