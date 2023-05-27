import React, {useEffect, useState} from 'react';
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";
import {FavoriteRequester} from "../../APIHelper/Requesters/FavoriteRequester";
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";
import styles from "./FavoritePage.module.css"
import {NavigateFunction, useNavigate} from "react-router-dom";

async function GetFavoritesAsync(navigate: NavigateFunction): Promise<ProductShortDTO[] | undefined>{
    try {
        let response = await FavoriteRequester.GetAllFavoritesAsync()
        return response.data;
    }
    catch (e: any){ // AxiosError
        if (e.response.status === 401)
            navigate("/Auth");
        alert(e);
    }
}

function DrawProducts(products: ProductShortDTO[]): JSX.Element[] {
    return products.map((p) =>
        <ProductCardComp product={p} initIsFavorited={true} initCount={0} />);
}

const FavoritePage = () => {
    const [products, setProducts] = useState<ProductShortDTO[] | null>(null);
    const navigate = useNavigate();

    useEffect(() => {(async () => {
        setProducts(await (GetFavoritesAsync(navigate)) ?? []);
    })()}, [])

    if (products === null)
        return (<>
            <h1 className={styles.Centered}>Избранное</h1>
            <div className={styles.Centered}>Загрузка...</div>
        </>);

    return (
        <>
            <h1 className={styles.Centered}>Избранное</h1>
            <div className={styles.ProductsContainer}>
                {DrawProducts(products)}
            </div>
        </>
    );


};

export default FavoritePage;