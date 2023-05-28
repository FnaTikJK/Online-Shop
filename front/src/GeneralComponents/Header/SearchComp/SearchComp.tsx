import React from 'react';
import Search from "antd/lib/input/Search";
import styles from "./SearchComp.module.css";
import {useSearchParams} from "react-router-dom";

const SearchComp = () => {
    const [searchParams, setSearchParams] = useSearchParams();

    return (
        <div className={styles.Search}>
            <Search
                placeholder={"Поиск"}
                allowClear
                enterButton={"Поиск"}
                size={"large"}
                onSearch={(v, e) => setSearchParams({text: v.trim()})}
            />
        </div>
    );
};

export default SearchComp;