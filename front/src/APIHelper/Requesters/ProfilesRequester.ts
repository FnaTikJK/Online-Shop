import axios from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";

interface ProfileDto{
    secondName: string;
    firstName: string;
    thirdName?: string;
    birthDate: string;
    email?: string;
    phoneNumber?: string;
}

export class ProfilesRequester{
    public static async GetOwnProfile() {
        axios.defaults.headers.post['Access-Control-Allow-Credentials']="*";
        return await axios.get<ProfileDto>(ApiRouteBuilder.Profiles.Build(),
            {
            headers:{  }
            });
    }

    public static UpdateProfile(profile: ProfileDto) {

    }
}