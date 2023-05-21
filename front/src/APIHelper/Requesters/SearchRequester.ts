import {GUID} from "../../Infrastructure/Guid";
import axios, {AxiosResponse} from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {ProductShortDTO} from "./ProductRequester";


export interface SearchRequestDTO{
    text: string,
    categoriesId?: GUID[],
    pageSize: number,
    pageNumber: number,
}

export interface SearchResponseDTO{
    pageSize: number,
    pageNumber: number,
    totalCount: number,
    items: ProductShortDTO[],
}

export class SearchRequester {
    public static async SearchAsync(request: SearchRequestDTO): Promise<AxiosResponse<SearchResponseDTO[]>>{
        return await axios.get<SearchResponseDTO[]>(ApiRouteBuilder.Search.Build(), {
            params: {
                text: request.text
            }
        })
    }
}