import React from 'react';
import './App.css';
import RegisterAuthPage from "./Pages/RegisterAuth/RegisterAuthPage";
import { Route, Routes} from "react-router-dom";
import HomePage from "./Pages/Home/HomePage";
import HeaderComp from "./GeneralComponents/Header/HeaderComp";
import BasketPage from "./Pages/Basket/BasketPage";
import ProfileInfoPage from "./Pages/ProfileOptionsList/ProfileInfo/ProfileInfoPage";
import ProfileOptionsListPage from "./Pages/ProfileOptionsList/ProfileOptionsListPage";
import FavoritePage from "./Pages/Favorite/FavoritePage";
import ProductPage from "./Pages/Product/ProductPage";

function App() {
    return (
    <Routes>
        <Route path={"/"} element={<HeaderComp />}>
            <Route index element={<HomePage/>}/>
            <Route path={"/Products/:id"} element={<ProductPage />}/>
            <Route path={"Basket"} element={<BasketPage />}/>
            <Route path={"Favorites"} element={<FavoritePage />}/>
            <Route path={"Profile"} element={<ProfileOptionsListPage />}/>
            <Route path={"Profile/Info"} element={<ProfileInfoPage />}/>
            <Route path={"Auth"} element={<RegisterAuthPage />}/>
        </Route>
    </Routes>
  );
}

export default App;
