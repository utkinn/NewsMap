import {httpClient} from "../httpClient";

export async function login(email: string, password: string) {
    await httpClient.post("/Auth/login", {email, password});
}
