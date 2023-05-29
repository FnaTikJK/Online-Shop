import React, {Dispatch, SetStateAction, useState} from 'react';
import {Button} from "antd";
import {FallOutlined, RiseOutlined} from "@ant-design/icons"

type Props = {
    addParams: (key: string, value: string | string[]) => void,
}

function SetField(field: string, addParams: (key: string, value: string | string[]) => void){
    addParams("orderBy", field);
}

function SetDescending(descending: boolean, setDescending: Dispatch<SetStateAction<boolean>>,
                       addParams: (key: string, value: string | string[]) => void){
    descending = !descending;
    setDescending(descending);
    addParams("descending", String(descending));
}

const SortingComp = ({addParams}: Props) => {
    const [descending, setDescending] = useState<boolean>(false);

    return (
        <div>
            <h3>Сортировка</h3>
            по
            <select name="Sorting" onChange={(v) => SetField(v.target.value, addParams)}>
                <option onClick={() => SetField("", addParams)}></option>
                <option value="Name" onClick={() => SetField("Name", addParams)}>Названию</option>
                <option value="Price" onClick={() => SetField("Price", addParams)}>Цене</option>
            </select>
            <Button onClick={() => SetDescending(descending, setDescending, addParams)}>
                {descending ? <FallOutlined /> : <RiseOutlined />}
            </Button>
        </div>
    );
};

export default SortingComp;