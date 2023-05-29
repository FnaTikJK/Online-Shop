import React, {useContext, useState} from 'react';
import {PlusOutlined, MinusOutlined} from "@ant-design/icons";
import {GUID} from "../../Infrastructure/Guid";
import {Button} from "antd";
import {BasketRequester} from "../../APIHelper/Requesters/BasketRequester";
import {BasketCountContext} from "../../CommonResources";
import {useNavigate} from "react-router-dom";

type Props = {
    id: GUID,
    initCount: number,
    setSummaryFunc?: (delta: number) => void
}

const ProductBasketManagerComp = ({id, initCount, setSummaryFunc}: Props) => {
    const [count, setCount] = useState<number>(initCount);
    const basketCountType = useContext(BasketCountContext);
    const navigate = useNavigate();

    return count > 0 ?
        (<>
            <MinusOutlined onClick={() => ChangeCountInBasket(count, count - 1)}></MinusOutlined>
            {count}
            <PlusOutlined onClick={() => ChangeCountInBasket(count, count + 1)}></PlusOutlined>
        </>)
        :
        (<>
            <Button onClick={() => ChangeCountInBasket(count, count + 1)}>Добавить в корзину</Button>
        </>);

    async function ChangeCountInBasket(oldCount: number, newCount: number, ){
        try {
            let response = await BasketRequester.UpdateOrAddItemAsync({
                productId: id,
                count: newCount
            })
            basketCountType?.setCountInBasket(response.data);
            setCount(newCount);
            if (setSummaryFunc)
                setSummaryFunc(newCount - oldCount);
        }
        catch(e: any) {
            if (e.response.status === 401 || e.response.status === 403)
                navigate("Auth");
            else
                alert(e);
        }
    }

    async function RemoveFromBasket(){
        let was = count;
        try {
            setCount(0);
            await BasketRequester.RemoveItemAsync(id);
        }
        catch(e) {
            setCount(was);
            alert(e);
        }
    }
};

export default ProductBasketManagerComp;