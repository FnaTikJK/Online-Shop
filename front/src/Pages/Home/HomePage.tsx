import React, {useEffect, useState} from 'react';
import {ProfileDto, ProfilesRequester} from "../../APIHelper/Requesters/ProfilesRequester";
import {ProductDto, ProductRequester} from "../../APIHelper/Requesters/ProductRequester";
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";
import {AxiosResponse} from "axios/index";

const HomePage = () => {
    const [products, setProducts] = useState<ProductDto[] | null>(null);

    useEffect(() => {
        GetProductsAsync()
    }, [])

    if (products === null)
        return (
            <>
                Loading...
            </>
        );

    return (
        <>
            {products.map((p) =>
            <ProductCardComp product={p} initIsFavorited={false} initCount={0}/>
            )}
        </>
    );

    async function GetProductsAsync(){
        try {
            let response: AxiosResponse<ProductDto[]> = await ProductRequester.GetAllProducts();
            setProducts(response.data);
        }
        catch (e: any){ // AxiosError
            alert(`Ошибка ${e.response.status}. ${e.response.text}`);
        }
    }
};

export default HomePage;