import React, {useContext, useEffect, useState} from 'react';
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";
import {AxiosResponse} from "axios";
import styles from "./HomePage.module.css"
import {SearchRequestDTO, SearchRequester, SearchResponseDTO} from "../../APIHelper/Requesters/SearchRequester";
import {useSearchParams} from "react-router-dom";
import {Guid} from "../../Infrastructure/Guid";
import {SearchContext} from "../../CommonResources";
import FiltersComp from "./FiltersComp/FiltersComp";

async function GetSearchResultAsync(searchRequest: SearchRequestDTO): Promise<SearchResponseDTO | undefined>{
    try {
        let response: AxiosResponse<SearchResponseDTO> = await SearchRequester.SearchAsync(searchRequest);
        return response.data;
    }
    catch (e: any){ // AxiosError
        alert(`Ошибка ${e.response.status}. ${e.response.text}`);
    }
}

function ParseSearchParams(searchParams: URLSearchParams): SearchRequestDTO{
    let response: SearchRequestDTO= {};
    let text = searchParams.get("text");
    if (text)
        response.text = text;
    let categoriesId = searchParams.get("categoriesId")
    if (categoriesId)
        response.categoriesId = categoriesId.split(" ").map(c => Guid(c));
    let pageSize = searchParams.get("pageSize")
    if (pageSize)
        response.pageSize = Number(pageSize);
    let pageNumber = searchParams.get("pageNumber")
    if (pageNumber)
        response.pageNumber = Number(pageNumber);
    return response;
}

const HomePage = () => {
    const [searchResponse, setSearchResponse] = useState<SearchResponseDTO | null | undefined>(null);
    const [searchParams, setSearchParams] = useSearchParams();

    useEffect(() => {(async () => {
        let searchRequest = ParseSearchParams(searchParams);
        setSearchResponse(await GetSearchResultAsync(searchRequest));
        setSearchParams(searchParams);
    })()}, [searchParams])

    if (searchResponse === null)
        return (
            <div className={styles.DivMain}>
                Loading...
            </div>
        );

    return (
        <div className={styles.DivMain}>
            <div className={styles.DivFilters}>
                <FiltersComp />
            </div>

            <div className={styles.DivProducts}>
                {searchResponse?.items?.map((p) =>
                <ProductCardComp product={p} initIsFavorited={false} initCount={0}/>
                )}
                Номер стр = {searchResponse?.pageNumber}
                Всего = {searchResponse?.totalCount}
            </div>
        </div>
    );


};

export default HomePage;