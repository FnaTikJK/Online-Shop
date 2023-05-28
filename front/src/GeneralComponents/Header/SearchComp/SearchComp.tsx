import React from 'react';
import Search from "antd/lib/input/Search";
import styles from "./SearchComp.module.css";
import {useSearchParams} from "react-router-dom";

function SetSearchText(searchParams: URLSearchParams, setSearchParams: any, text: string){
    text = text.trim();
    if (text !== ""){
        searchParams.set("text", text);
        setSearchParams(searchParams);
    }
}

const SearchComp = () => {
    const [searchParams, setSearchParams] = useSearchParams();

    return (
        <div className={styles.Search}>
            <Search
                placeholder={"Поиск"}
                enterButton={"Поиск"}
                allowClear
                size={"large"}
                onSearch={(v, e) => SetSearchText(searchParams, setSearchParams, v)}
            />
        </div>
    );
};

export default SearchComp;