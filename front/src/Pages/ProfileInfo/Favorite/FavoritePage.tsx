import React, {useEffect, useState} from 'react';
import {ProductDto} from "../../../APIHelper/Requesters/ProductRequester";
import {FavoriteRequester} from "../../../APIHelper/Requesters/FavoriteRequester";
import ProductCardComp from "../../../GeneralComponents/ProductCard/ProductCardComp";

const FavoritePage = () => {
    const [products, setProducts] = useState<ProductDto[] | null>(null);

    useEffect(() => {
        GetFavoritesAsync();
    }, [])

    return (
        <>
            <h1>Избранное</h1>
            {products?.map((p) =>
                <ProductCardComp product={p}/>
            )}
        </>
    );

    async function GetFavoritesAsync(){
        try {
            let response = await FavoriteRequester.GetAllFavoritesAsync()
            setProducts(response.data);
        }
        catch (e){ // AxiosError
            alert(e);
        }
    }
};

export default FavoritePage;