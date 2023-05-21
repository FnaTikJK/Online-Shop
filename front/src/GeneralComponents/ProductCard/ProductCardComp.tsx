import React from 'react';
import {Card} from "antd";
import ProductFavoriteComp from "../ProductFavoriteComp/ProductFavoriteComp";
import ProductBasketManagerComp from "../ProductBasketManager/ProductBasketManagerComp";
import {ProductShortDTO} from "../../APIHelper/Requesters/ProductRequester";

type Props ={
    product: ProductShortDTO,
    initIsFavorited: boolean,
    initCount: number,
}

const ProductCardComp = ({product, initIsFavorited, initCount}: Props) => {
    const urlNoImage = "https://xphoto.name/uploads/posts/2021-12/1639200680_20-xphoto-name-p-cp-link-porn-jailbait-34.jpg";

    return (
        <>
            <Card
                style={{ width: "100%" }}
                cover={
                    <img
                        alt={product.name}
                        src={urlNoImage}
                    />
                }
                actions={[
                    <ProductFavoriteComp id={product.id} initIsFavorited={initIsFavorited} />,
                    <ProductBasketManagerComp id={product.id} initCount={initCount} />
                ]}
            >
                <Card.Meta
                    title={product.name}
                    description={product.categories.map((c) =>
                        <button>{c.name}</button>)}
                />
            </Card>
        </>
    );
};

export default ProductCardComp;