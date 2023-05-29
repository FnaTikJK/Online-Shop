import React, {useEffect, useState} from 'react';
import {useSearchParams} from "react-router-dom";
import {Button} from 'antd';
import styles from "./FiltersComp.module.css";
import SliderComp from "./SliderComp/SliderComp";
import CategoriesComp from "./CategoriesComp/CategoriesComp";
import {FiltersDTO, SearchRequester} from "../../../APIHelper/Requesters/SearchRequester";
import SortingComp from "./SortingComp/SortingComp";

let filterParams: {[key: string]: string | string[]} = {};

async function GetFiltersAsync(): Promise<FiltersDTO | undefined>{
    try {
        let response = await SearchRequester.GetFiltersAsync();
        return response.data
    }
    catch (e) {
        alert(e);
    }
}

function AddParams(key: string, value: string | string[]){
    filterParams[key] = value;
}

function ApplyParams(searchParams: URLSearchParams, setSearchParams: any){
    for(let key in filterParams) {
        if (typeof filterParams[key] === "string") {
            if (filterParams[key] === "")
                searchParams.delete(key);
            else
                searchParams.set(key, filterParams[key] as string);
        }
        else {
            searchParams.delete(key);
            (filterParams[key] as string[]).forEach(e => searchParams.append(key, e));
        }
    }
    setSearchParams(searchParams);
}

function ResetParams(searchParams: URLSearchParams, setSearchParams: any){
    for(let key in filterParams)
        searchParams.delete(key);
    setSearchParams(searchParams);
}

const FiltersComp = () => {
    const [searchParams, setSearchParams] = useSearchParams();
    const [filters, setFilters] = useState<FiltersDTO | undefined>(undefined);

    useEffect(() => {(async () => {
        setFilters(await GetFiltersAsync());
    })()}, [])

    if (!filters)
        return (<div>Загрузка...</div>);

    return (
        <div className={styles.DivMain}>
            <SliderComp initFrom={filters.from} initTo={filters.to} addParams={AddParams}/>
            <SortingComp addParams={AddParams}/>
            <CategoriesComp categories={filters.categories} addParams={AddParams}/>
            <Button onClick={() => ApplyParams(searchParams, setSearchParams)}>Применить</Button>
            <Button onClick={() => ResetParams(searchParams, setSearchParams)}>Сбросить</Button>
        </div>
    );
};

export default FiltersComp;