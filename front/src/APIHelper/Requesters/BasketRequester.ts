import axios, {AxiosResponse} from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {GUID} from "../../Infrastructure/Guid";
import {ProductShortDTO} from "./ProductRequester";

interface BasketItemAddDTO {
    productId: GUID,
    count: number,
}

export interface BasketItemDTO {
    product: ProductShortDTO,
    count: number,
}

export class BasketRequester{
    public static async GetAllItemsAsync(): Promise<AxiosResponse<BasketItemDTO[]>>{
        return await axios.get<BasketItemDTO[]>(ApiRouteBuilder.Baskets.Build());
    }

    public static async UpdateOrAddItemAsync(item: BasketItemAddDTO): Promise<AxiosResponse>{
        return await axios.put(ApiRouteBuilder.Baskets.Build(), {
            productId: item.productId,
            count: item.count,
        });
    }

    public static async RemoveItemAsync(productId: GUID): Promise<AxiosResponse>{
        return await axios.delete(ApiRouteBuilder.Baskets.With(productId).Build());
    }
}