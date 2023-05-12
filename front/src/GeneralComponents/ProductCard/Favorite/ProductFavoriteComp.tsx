import React, {useState} from 'react';
import {HeartOutlined, HeartFilled} from "@ant-design/icons";
import {GUID} from "../../../Infrastructure/Guid";
import {FavoriteRequester} from "../../../APIHelper/Requesters/FavoriteRequester";

type Props = {
    id: GUID,
    initIsFavorited: boolean,
}

const ProductFavoriteComp = ({id, initIsFavorited}: Props) => {
    const [isFavorited, setIsFavorited] = useState<boolean>(initIsFavorited)

    return (
        <>
            {isFavorited ?
                <HeartFilled onClick={()=>RemoveFromFavorite()}/>
                : <HeartOutlined onClick={()=>AddToFavorite()}/>
            }
        </>
    );

    async function AddToFavorite(){
        setIsFavorited(true);
        try {
            await FavoriteRequester.AddFavoriteAsync(id);
        }
        catch (e){
            alert(e);
            setIsFavorited(false);
        }
    }

    async function RemoveFromFavorite(){
        setIsFavorited(false);
        try {
            await FavoriteRequester.RemoveFavoriteAsync(id);
        }
        catch (e){
            alert(e);
            setIsFavorited(true);
        }
    }
};

export default ProductFavoriteComp;