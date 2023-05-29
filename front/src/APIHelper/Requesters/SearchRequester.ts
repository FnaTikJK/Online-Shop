import {GUID} from "../../Infrastructure/Guid";
import axios, {AxiosResponse} from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {ProductShortDTO} from "./ProductRequester";
import qs from "qs";


export interface SearchRequestDTO{
    text?: string,
    categoriesId?: GUID[],
    pageSize?: number,
    pageNumber?: number,
    priceFrom?: number,
    priceTo?: number,
    orderBy?: "Name" | "Price",
    descending?: boolean,
}

export interface SearchResponseDTO{
    pageSize: number,
    pageNumber: number,
    totalPageCount: number,
    items: ProductShortDTO[],
}

export interface FiltersDTO{
    categories: {id:GUID, name:string}[],
    from: number,
    to: number
}

export class SearchRequester {
    public static async SearchAsync(request: SearchRequestDTO): Promise<AxiosResponse<SearchResponseDTO>>{
        return await axios.get<SearchResponseDTO>(ApiRouteBuilder.Search.Build(), {
            params: {
                text: request.text,
                categoriesId: request.categoriesId,
                pageSize: request.pageSize,
                pageNumber: request.pageNumber,
                priceFrom: request.priceFrom,
                priceTo: request.priceTo,
                orderBy: request.orderBy,
                descending: request.descending
            },
            paramsSerializer: params => {
                return qs.stringify(params, { arrayFormat: "repeat" })
            }
        })
    }

    public static async GetFiltersAsync(): Promise<AxiosResponse<FiltersDTO>>{
        return await axios.get<FiltersDTO>(ApiRouteBuilder.Search.With("Filters").Build());
    }
}