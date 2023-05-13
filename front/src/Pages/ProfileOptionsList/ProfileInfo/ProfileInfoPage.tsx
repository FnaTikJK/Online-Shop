import React, {useEffect, useState} from 'react';
import {ProfileDto, ProfilesRequester} from "../../APIHelper/Requesters/ProfilesRequester";
import {useNavigate} from "react-router-dom";
import {AxiosResponse} from "axios";
import {Menu} from 'antd';
import {AccountsRequester} from "../../APIHelper/Requesters/AccountsRequester";

const ProfileInfoPage = () => {
    let navigate = useNavigate();
    const [profileInfo, setProfileInfo] = useState<ProfileDto | null>(null);

    useEffect(() => {
        FetchProfileInfoAsync();
    }, [])

    if (profileInfo === null)
        return (
            <>
                Loading...
            </>
        );

    return (
        <>
            <Menu title={"Учётные данные"}>
                <Menu.ItemGroup title={"ФИО"}>
                    <Menu.Item title={"Фамилия"}>{profileInfo.secondName}</Menu.Item>
                    <Menu.Item title={"Имя"}>{profileInfo.firstName}</Menu.Item>
                    <Menu.Item title={"Отчество"}>{profileInfo.thirdName ?? "Не указано"}</Menu.Item>
                </Menu.ItemGroup>
                <Menu.ItemGroup title={"Личные данные"}>
                    <Menu.Item title={"Дата рождения"}>{profileInfo.birthDate}</Menu.Item>
                    <Menu.Item title={"Пол"}>Пол не реализован</Menu.Item>
                </Menu.ItemGroup>
                <Menu.ItemGroup title={"Контакты"}>
                    <Menu.Item title={"Телефон"}>{profileInfo.phoneNumber ?? "Не указано"}</Menu.Item>
                    <Menu.Item title={"Эл. почта"}>{profileInfo.email ?? "Не указано"}</Menu.Item>
                </Menu.ItemGroup>
                <Menu.ItemGroup title={"Действия"}>
                    <Menu.Item title={"Выход"} style={{color:"red"}} onClick={() => LogoutAsync(navigate)}>
                        Выход
                    </Menu.Item>
                </Menu.ItemGroup>
            </Menu>
        </>
    );

    async function FetchProfileInfoAsync(){
        try {
            let response: AxiosResponse<ProfileDto> = await ProfilesRequester.GetOwnProfileInfoAsync();
            setProfileInfo(response.data);
        }
        catch (e: any){ // AxiosError
            if (e.response.status === 401 ||  e.response.status === 403)
                navigate("/Auth");
            else
                alert(`Ошибка ${e.response.status}. ${e.response.text}`);
        }
    }

    async function LogoutAsync(navigate: any){
        await AccountsRequester.LogoutAsync();
        navigate("/Auth");
    }
};

export default ProfileInfoPage;