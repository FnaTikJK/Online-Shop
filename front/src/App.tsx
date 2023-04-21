import React from 'react';
import './App.css';
import RegisterAuthPage from "./Pages/RegisterAuth/RegisterAuthPage";
import { Route, Routes} from "react-router-dom";
import FooterComp from "./GeneralComponents/FooterComp";
import HomePage from "./Pages/Home/HomePage";
import HeaderComp from "./GeneralComponents/HeaderComp";
import BasketPage from "./Pages/Basket/BasketPage";

function App() {
    return (
    <Routes>
        <Route path={"/"} element={<FooterComp />}>
            <Route path={"/"} element={<HeaderComp />}>
                <Route index element={<HomePage/>}/>
            </Route>
            <Route path={"Basket"} element={<BasketPage />}/>
            <Route path={"Auth"} element={<RegisterAuthPage />}/>
        </Route>
    </Routes>
  );
}

export default App;
