import React, {useEffect, useState} from 'react';
import {ProductDto} from "../APIHelper/Requesters/ProductRequester";
import {Card} from "antd";
import {HeartOutlined, PlusOutlined, MinusOutlined} from "@ant-design/icons";

type Props ={
    product: ProductDto
}

const ProductCardComp = ({product}: Props) => {
    const [actions, setActions] = useState([
        <HeartOutlined />,
        <PlusOutlined />])
    let [isAdded, setAdded] = useState(false);
    let [isFavorite, setFavorite] = useState(false);

    useEffect(() =>{
        SetAddedButtons();
        console.log(isAdded)
        console.log(isFavorite)
    }, [isAdded, isFavorite])

    return (
        <>
            <Card
                style={{ width: 300 }}
                cover={
                    <img
                        alt="example"
                        src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
                    />
                }
                actions={actions}
            >
                <Card.Meta
                    title={product.name}
                    description={product.categories.map((c) =>
                        <button>{c.name}</button>)}
                />
            </Card>
        </>
    );

    function SetAddedButtons() {
        let actions = []
        actions.push(isFavorite ? <HeartOutlined style={{color:"red"}} onClick={()=>isFavorite=false}/>
            : <HeartOutlined onClick={()=>isFavorite=true}/>)
        actions.push(isAdded ? <MinusOutlined onClick={()=>setAdded(false)}/>
            : <PlusOutlined onClick={()=>AddToBasket()}/>)

        setActions(actions);
    }

    function AddToBasket(){

    }

    function RemoveFromBasket(){

    }

    function AddToFavorite(){

    }

    function RemoveFromFavorite(){

    }
};

export default ProductCardComp;