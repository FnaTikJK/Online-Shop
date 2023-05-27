import React, {useContext, useState} from 'react';
import {HeartOutlined, HeartFilled} from "@ant-design/icons";
import {GUID} from "../../Infrastructure/Guid";
import {FavoriteRequester} from "../../APIHelper/Requesters/FavoriteRequester";
import {FavoritesContext} from "../../CommonResources";

type Props = {
    id: GUID,
    initIsFavorited: boolean,
}

const ProductFavoriteComp = ({id, initIsFavorited}: Props) => {
    const [isFavorited, setIsFavorited] = useState<boolean>(initIsFavorited)
    const favoriteType = useContext(FavoritesContext);

    return (
        <>
            {isFavorited ?
                <HeartFilled onClick={()=>RemoveFromFavorite()} style={{verticalAlign: 'middle', margin:"4.5px"}}/>
                : <HeartOutlined onClick={()=>AddToFavorite()} style={{verticalAlign: 'middle', margin:"4.5px"}}/>
            }
        </>
    );

    async function AddToFavorite(){
        setIsFavorited(true);
        try {
            let response = await FavoriteRequester.AddFavoriteAsync(id);
            if (response.data !== undefined)
                favoriteType?.setFavorites(response.data);
        }
        catch (e){
            alert(e);
            setIsFavorited(false);
        }
    }

    async function RemoveFromFavorite(){
        setIsFavorited(false);
        try {
            let response = await FavoriteRequester.RemoveFavoriteAsync(id);
            if (response.data !== undefined)
                favoriteType?.setFavorites(response.data);
        }
        catch (e){
            alert(e);
            setIsFavorited(true);
        }
    }
};

export default ProductFavoriteComp;