import React, {useState} from 'react';
import {Outlet} from "react-router-dom";
import {Button} from "antd";
import Search from "antd/lib/input/Search";

const HeaderComp = () => {
    const [pageState, setPageState] = useState<"Simple" | "Categories">("Simple");

    if (pageState === "Simple")
        return (
            <>
                <Search
                    placeholder={"input"}
                    allowClear
                    enterButton={"Search"}
                    size={"large"}
                    suffix={<Button onClick={() => setPageState("Categories")}>Cat</Button>}
                />

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