import React, {Dispatch, SetStateAction, useState} from 'react';
import {InputNumber, Slider} from "antd";
import styles from "./SliderComp.module.css";

type Props = {
    initFrom: number,
    initTo: number,
    addParams: (key: string, value: string) => void;
}

function SetInputValues(values: number[], addParams: (key: string, value: string) => void,
                        setFrom: Dispatch<SetStateAction<number>>, setTo: Dispatch<SetStateAction<number>>) {
    let min = Math.min(...values);
    let max = Math.max(...values);
    addParams("priceFrom", String(min))
    addParams("priceTo", String(max))
    setFrom(min);
    setTo(max);
}

const SliderComp = ({initFrom, initTo, addParams}: Props) => {
    const [from, setFrom] = useState<number>(initFrom);
    const [to, setTo] = useState<number>(initTo);

    return (
        <div>
            <Slider range min={initFrom} max={initTo}
                    value={[from, to]}
                    onChange={(values) => SetInputValues(values, addParams, setFrom, setTo)} />
            <div className={styles.Text}>от</div>
            <InputNumber min={initFrom} max={to} value={from}
                onChange={(v) => setFrom(v ? v : from)}/>
            <div className={styles.Text}>до</div>
            <InputNumber min={from} max={initTo} value={to}
                onChange={(v) => setTo(v ? v : to)}
            />
        </div>
    );
};

export default SliderComp;