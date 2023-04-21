import axios from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";

interface RegisterDto {
    login: string,
    password: string,
    secondName: string,
    firstName: string,
    thirdName: string | null,
    birthDate: string | null,
}

interface LoginDto {
    login: string,
    password: string
}

export class AccountsRequester {
    public static Register(data: RegisterDto){
        axios.post(ApiRouteBuilder.Accounts.Register.Build(), data);
    }

    public static Login(data: LoginDto){
        axios.post(ApiRouteBuilder.Accounts.Login.Build(), data);
    }

    public static Logout(){
        axios.post(ApiRouteBuilder.Accounts.Logout.Build());
    }
}