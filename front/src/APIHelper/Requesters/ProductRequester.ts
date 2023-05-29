import axios, {AxiosResponse} from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {GUID} from "../../Infrastructure/Guid";
import {CategoryShortDto} from "./CategoriesReqester";

export interface ProductDto{
    id: GUID,
    name: string,
    description: string,
    price: number,
    categories: CategoryShortDto[],
    image: string | null,
}

export interface ProductShortDTO{
    id: GUID,
    name: string,
    price: number,
    categories: CategoryShortDto[],
    image: string | null,
    isFavorited: boolean,
    countInBasket: number
}

export class ProductRequester{
    public static async GetAllProducts(): Promise<AxiosResponse<ProductDto[]>>{
        return await axios.get<ProductDto[]>(ApiRouteBuilder.Products.Build());
    }

    public static async GetProductByIdAsync(id: GUID): Promise<AxiosResponse<ProductDto>>{
        return await axios.get<ProductDto>(ApiRouteBuilder.Products.With(id).Build());
    }
}