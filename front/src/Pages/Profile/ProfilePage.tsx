import React, {useEffect} from 'react';
import {ProfilesRequester} from "../../APIHelper/Requesters/ProfilesRequester";
import {useNavigate} from "react-router-dom";

const ProfilePage = () => {
    let navigate = useNavigate();
    let info;
    if (info === null){
        navigate("/Auth");
    }

    useEffect(() => {
        let info = ProfilesRequester.GetOwnProfile()
            .then(e => console.log(e));
        if (info === null)
            navigate("/Auth");
    }, [])



    return (
        <>

        </>
    );
};

export default ProfilePage;