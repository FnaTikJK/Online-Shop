export class ApiRouteBuilder {
    public static BaseUrl: ApiRouteBuilder = new ApiRouteBuilder("/api");

    private static AccountsBase: ApiRouteBuilder = ApiRouteBuilder.BaseUrl.With("Accounts");
    public static Accounts = {
        Register: this.AccountsBase.With("Register"),
        Login: this.AccountsBase.With("Login"),
        Logout: this.AccountsBase.With("Logout"),
    }

    private static ProfilesBase: ApiRouteBuilder = ApiRouteBuilder.BaseUrl.With("Profiles")
    public static Profiles ={
        Own: ApiRouteBuilder.ProfilesBase.With("Own"),
    }

    public static Products = ApiRouteBuilder.BaseUrl.With("Products");

    public static Favorites = ApiRouteBuilder.BaseUrl.With("Favorites");

    public static Baskets = ApiRouteBuilder.BaseUrl.With("Baskets");

    public static Search = ApiRouteBuilder.BaseUrl.With("Search");







    private route: string;
    private queryParams: { [key:string]: string } = {};
    private constructor(route: string) {
        this.route = route;
    }

    public WithQuery(queryParams: { [key:string]: string }){
        this.queryParams = queryParams;
    }

    public With(path: string){
        return new ApiRouteBuilder(this.route + "/" + path)
    }

    public Build(){
        let res = this.route;
        let queryAdded = false;
        for(let key in this.queryParams){
            if (!queryAdded)
            {
                queryAdded = true;
                res += "&";
            }
            res += `${key}=${this.queryParams[key]}`
        }
        return res;
    }
}