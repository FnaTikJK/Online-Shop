export class RouteBuilder{
    public static BaseUrl: RouteBuilder = new RouteBuilder("https://localhost:7055/api/");
    private static AccountsBase: RouteBuilder = RouteBuilder.BaseUrl.With("Accounts");
    public static Accounts = {
        Register: this.AccountsBase.With("Register"),
        Login: this.AccountsBase.With("Login"),
        Logout: this.AccountsBase.With("Logout"),
    }

    private route: string;
    private queryParams: { [key:string]: string } = {};
    private constructor(route: string) {
        this.route = route;
    }

    public WithQuery(queryParams: { [key:string]: string }){
        this.queryParams = queryParams;
    }

    public With(path: string){
        return new RouteBuilder(this.route + path + "/")
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