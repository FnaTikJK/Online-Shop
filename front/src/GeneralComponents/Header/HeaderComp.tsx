import React, {useState} from 'react';
import {Outlet, useNavigate} from "react-router-dom";
import {Button} from "antd";
import Search from "antd/lib/input/Search";
import styles from "./HeaderComp.module.css";
import {HeartOutlined, ShoppingCartOutlined, UserOutlined} from "@ant-design/icons";

const HeaderComp = () => {
    const [pageState, setPageState] = useState<"Simple" | "Categories">("Simple");
    const navigate = useNavigate();

    if (pageState === "Simple")
        return (
            <>
                <div className={styles.Mock}/>
                <header className={styles.Header}>
                    <div className={styles.Logo}>Logo</div>
                    <div className={styles.Search}>
                        <Search
                            placeholder={"Поиск"}
                            allowClear
                            enterButton={"Поиск"}
                            size={"large"}
                            suffix={<Button onClick={() => setPageState("Categories")}>Cat</Button>}
                        />
                    </div>

                    <div className={styles.Navigation}>
                        <UserOutlined style={{ fontSize: '25px' }} onClick={() => {navigate("Profile")}}/>
                        <HeartOutlined
                            style={{  fontSize: '25px', marginLeft:"10px" }} onClick={() => {navigate("Favorites")}}/>
                        <ShoppingCartOutlined
                            style={{ fontSize: '25px', marginLeft:"10px" }} onClick={() => {navigate("Basket")}}/>
                    </div>
                </header>

                <Outlet />
            </>
        );
    else
        return (
            <>
                <Button onClick={() => setPageState("Simple")}>Back</Button>
            </>
        )
};

export default HeaderComp;