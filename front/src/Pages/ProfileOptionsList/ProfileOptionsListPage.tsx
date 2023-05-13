import React, {useEffect, useState} from 'react';
import {Button, Menu} from 'antd';
import {useNavigate} from "react-router-dom";
import {ProfileDto, ProfilesRequester} from "../../APIHelper/Requesters/ProfilesRequester";
import {AxiosError, AxiosResponse} from "axios";

interface IListItem{
    text: string,
    link: string,
}

const ProfileOptionsPage = () => {
    const navigate = useNavigate();
    const data: IListItem[] = [
        { text: "Управление аккаунтом", link: "/Profile/Info" },
        { text: "Мои заказы", link: "/Profile/Orders" },
        { text: "Избранное", link: "/Profile/Favorites" },
    ];
    const [profileInfo, setProfileInfo] = useState<ProfileDto | null>(null);

    useEffect(() => {
        fetchProfileInfoAsync(navigate, setProfileInfo);
    }, []);

    if (profileInfo === null)
        return (
            <>
                Loading...
            </>
        );

    return (
        <>
            <Menu>
                {data.map((item) =>
                    <Menu.Item onClick={() => navigate(item.link)}>
                        {item.text}
                    </Menu.Item>)}
            </Menu>
        </>
    );
};

async function fetchProfileInfoAsync(navigate: any, setProfileInfo: any){
    try {
        let response: AxiosResponse<ProfileDto> = await ProfilesRequester.GetOwnProfileInfoAsync();
        setProfileInfo(response.data);
    }
    catch (e: any){ // AxiosError
        if (e.response.status === 401 ||  e.response.status === 403)
            navigate("/Auth");
        else
            alert(`Ошибка ${e.response.status} (${e.response.statusText}). ${e.response.data}`);
    }
}

export default ProfileOptionsPage;