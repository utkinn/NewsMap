import {httpClient} from "../httpClient";

export async function login(email: string, password: string) {
    const jwt = await httpClient.post<string>("/Auth/login", {email, password});
    localStorage.setItem("jwt", jwt.data);
}
