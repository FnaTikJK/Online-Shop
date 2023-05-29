import React from 'react';
import {useSearchParams} from "react-router-dom";
import {Pagination} from "antd";

type Props = {
    current: number,
    total: number,
}

function SetPage(page: number, searchParams: URLSearchParams, setSearchParams: any){
    searchParams.set("pageNumber", String(page));
    setSearchParams(searchParams);
}

const PaginationComp = ({current, total}: Props) => {
    const [searchParams, setSearchParams] = useSearchParams();

    return (
        <div>
            <Pagination current={current} total={total*10}
                        onChange={(page, pageSize) => SetPage(page, searchParams, setSearchParams)}/>
        </div>
    );
};

export default PaginationComp;