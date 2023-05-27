import React, {useContext, useState} from 'react';
import {PlusOutlined, MinusOutlined} from "@ant-design/icons";
import {GUID} from "../../Infrastructure/Guid";
import {Button} from "antd";
import {BasketRequester} from "../../APIHelper/Requesters/BasketRequester";
import {BasketCountContext} from "../../CommonResources";

type Props = {
    id: GUID,
    initCount: number,
}

const ProductBasketManagerComp = ({id, initCount}: Props) => {
    const [count, setCount] = useState<number>(initCount);
    const basketCountType = useContext(BasketCountContext);

    return count > 0 ?
        (<>
            <MinusOutlined onClick={() => ChangeCountInBasket(count - 1)}></MinusOutlined>
            {count}
            <PlusOutlined onClick={() => ChangeCountInBasket(count + 1)}></PlusOutlined>
        </>)
        :
        (<>
            <Button onClick={() => ChangeCountInBasket(count + 1)}>Добавить в корзину</Button>
        </>);

    async function ChangeCountInBasket(count: number){
        try {

            let response = await BasketRequester.UpdateOrAddItemAsync({
                productId: id,
                count: count
            })
            basketCountType?.setCountInBasket(response.data);
            setCount(count);
        }
        catch(e) {
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