import React, {useEffect, useState} from 'react';
import ProductCardComp from "../../GeneralComponents/ProductCard/ProductCardComp";
import {AxiosResponse} from "axios";
import styles from "./HomePage.module.css"
import {SearchRequestDTO, SearchRequester, SearchResponseDTO} from "../../APIHelper/Requesters/SearchRequester";
import {useSearchParams} from "react-router-dom";
import {Guid} from "../../Infrastructure/Guid";
import FiltersComp from "./FiltersComp/FiltersComp";
import PaginationComp from "./PaginationComp/PaginationComp";
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";

async function GetSearchResultAsync(searchRequest: SearchRequestDTO): Promise<SearchResponseDTO | undefined>{
    try {
        let response: AxiosResponse<SearchResponseDTO> = await SearchRequester.SearchAsync(searchRequest, true);
        return response.data;
    }
    catch (e: any){ // AxiosError
        if (e.response?.status === 401){
            try{
                let response: AxiosResponse<SearchResponseDTO> = await SearchRequester.SearchAsync(searchRequest);
                return response.data;
            }
            catch (e: any){
                alert(`Ошибка ${e.response.status}. ${e.response.text}`);
            }
        }
    }
}

function ParseSearchParams(searchParams: URLSearchParams): SearchRequestDTO{
    let request: SearchRequestDTO= {};
    let text = searchParams.get("text");
    if (text)
        request.text = text;
    let categoriesId = searchParams.getAll("categoriesId")
    if (categoriesId)
        request.categoriesId = categoriesId.map(c => Guid(c));
    let pageSize = searchParams.get("pageSize")
    if (pageSize)
        request.pageSize = Number(pageSize);
    let pageNumber = searchParams.get("pageNumber")
    if (pageNumber)
        request.pageNumber = Number(pageNumber);
    let priceFrom = searchParams.get("priceFrom")
    if (priceFrom)
        request.priceFrom = Number(priceFrom);
    let priceTo = searchParams.get("priceTo")
    if (priceTo)
        request.priceTo = Number(priceTo);
    let orderBy = searchParams.get("orderBy") as ("Name" | "Price" | undefined)
    if (orderBy)
        request.orderBy = orderBy;
    let descending = searchParams.get("descending")
    if (descending)
        request.descending = descending !== "false";
    return request;
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
                <ProductCardComp product={p} initIsFavorited={p.isFavorited} initCount={p.countInBasket}/>
                )}

                <div>
                    <PaginationComp current={searchResponse?.pageNumber ?? 1} total={searchResponse?.totalPageCount ?? 10}/>
                </div>
            </div>
        </div>
    );


};

export default HomePage;