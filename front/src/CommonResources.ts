import React from "react";

export const urlNoImage = "https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png";

type favoritesStateType = {
    favorites: number,
    setFavorites: React.Dispatch<React.SetStateAction<number>>
}
export const FavoritesContext = React.createContext<favoritesStateType | null>(null);

type basketStateType = {
    countInBasket: number,
    setCountInBasket: React.Dispatch<React.SetStateAction<number>>
}
export const BasketCountContext = React.createContext<basketStateType | null>(null);