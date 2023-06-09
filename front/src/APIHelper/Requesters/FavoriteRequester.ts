import axios, {AxiosResponse} from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {GUID} from "../../Infrastructure/Guid";
import {ProductDto, ProductShortDTO} from "./ProductRequester";

export class FavoriteRequester{
    public static async GetAllFavoritesAsync(): Promise<AxiosResponse<ProductShortDTO[]>>{
        return await axios.get<ProductShortDTO[]>(ApiRouteBuilder.Favorites.Build());
    }

    public static async GetFavoritesCountAsync(): Promise<AxiosResponse<number>>{
        return await axios.get<number>(ApiRouteBuilder.Favorites.With("Count").Build());
    }

    public static async AddFavoriteAsync(id: GUID): Promise<AxiosResponse<number>>{
        return await axios.post(ApiRouteBuilder.Favorites.Build(), { productId: id });
    }

    public static async RemoveFavoriteAsync(id: GUID): Promise<AxiosResponse<number>>{
        return await axios.delete(ApiRouteBuilder.Favorites.With(id).Build());
    }
}