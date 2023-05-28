import React, {Dispatch, SetStateAction} from "react";
import {SearchRequestDTO} from "./APIHelper/Requesters/SearchRequester";

export const urlNoImage = "https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png";

type favoritesStateType = {
    favorites: number,
    setFavorites: Dispatch<SetStateAction<number>>
}
export const FavoritesContext = React.createContext<favoritesStateType | null>(null);

type basketStateType = {
    countInBasket: number,
    setCountInBasket: Dispatch<SetStateAction<number>>
}
export const BasketCountContext = React.createContext<basketStateType | null>(null);

type searchStateType = {
    searchRequest: SearchRequestDTO,
    setSearchRequest: Dispatch<SetStateAction<SearchRequestDTO>>
}
export const SearchContext = React.createContext<searchStateType | null>(null);