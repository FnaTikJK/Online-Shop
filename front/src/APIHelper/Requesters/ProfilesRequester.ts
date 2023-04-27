import axios from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";

export interface ProfileDto{
    secondName: string;
    firstName: string;
    thirdName?: string;
    birthDate: string;
    email?: string;
    phoneNumber?: string;
}

export class ProfilesRequester{
    public static async GetOwnProfileInfoAsync() {
        return await axios.get<ProfileDto>(ApiRouteBuilder.Profiles.Own.Build());
    }

    public static UpdateProfile(profile: ProfileDto) {

    }
}