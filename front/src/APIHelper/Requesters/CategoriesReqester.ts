import axios from "axios";
import {ApiRouteBuilder} from "../ApiRouteBuilder";
import {GUID} from "../../Infrastructure/Guid";

export interface CategoryShortDto{
    id: GUID,
    name: string
}

export class CategoriesRequester{
    public static async GetAllCategories(): Promise<CategoryShortDto[]>{
        throw new Error("Not Imp Category");
    }
}