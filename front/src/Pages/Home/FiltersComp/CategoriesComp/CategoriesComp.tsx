import React from 'react';
import { Checkbox } from 'antd';
import {GUID} from "../../../../Infrastructure/Guid";
import "./Categories.css";

type Props = {
    categories: {id: GUID, name: string}[],
    addParams: (key: string, value: string | string[]) => void,
}

function SetCategories(checkedValues: string[], addParams: (key: string, value: string | string[]) => void) {
    addParams("categoriesId", checkedValues);
}

const CategoriesComp = ({categories, addParams}: Props) => {
    return (
        <div>
            <h3>Категории</h3>
            <Checkbox.Group
                options={categories.map(c => ({label:c.name, value:c.id}))}
                onChange={(checkedValues) => SetCategories(checkedValues as string[], addParams)}/>
        </div>
    );
};

export default CategoriesComp;