import React, {useState} from 'react';
import {PlusOutlined, MinusOutlined} from "@ant-design/icons";
import {GUID} from "../../../Infrastructure/Guid";
import {Button} from "antd";
import {BasketRequester} from "../../../APIHelper/Requesters/BasketRequester";

type Props = {
    id: GUID,
    initCount: number,
}

const ProductBasketManagerComp = ({id, initCount}: Props) => {
    const [count, setCount] = useState<number>(initCount);

    return count > 0 ?
        (<>
            <MinusOutlined onClick={() => ReduceCountInBasket()}></MinusOutlined>
            {count}
            <PlusOutlined onClick={() => IncreaseCountInBasket()}></PlusOutlined>
        </>)
        :
        (<>
            <Button onClick={() => IncreaseCountInBasket()}>Добавить в корзину</Button>
        </>);

    async function IncreaseCountInBasket(){
        try {
            setCount(count + 1);
            await BasketRequester.UpdateOrAddItemAsync({
                productId: id,
                count: count + 1
            })
        }
        catch(e) {
            setCount(count - 1);
            alert(e);
        }
    }

    async function ReduceCountInBasket(){
        try {
            setCount(count - 1);
            await BasketRequester.UpdateOrAddItemAsync({
                productId: id,
                count: count - 1,
            })
        }
        catch(e) {
            setCount(count + 1);
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