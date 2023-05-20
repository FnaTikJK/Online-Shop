import React, {useEffect, useState} from 'react';
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";
import {FavoriteRequester} from "../../APIHelper/Requesters/FavoriteRequester";
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";

const FavoritePage = () => {
    const [products, setProducts] = useState<ProductShortDTO[] | null>(null);

    useEffect(() => {
        GetFavoritesAsync();
    }, [])

    return (
        <>
            <h1>Избранное</h1>
            {products === null ?
                <>
                    Loading...
                </>
                :
                    products.map((p) =>
                <ProductCardComp product={p} initIsFavorited={true} initCount={0}/>
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