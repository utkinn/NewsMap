import {JwtPayload as JwtPayloadBase} from "jwt-decode";
import {jwtDecode} from "jwt-decode";

export class User {
    constructor(private jwt: string) {
    }

    get isAdministrator(): boolean {
        return jwtDecode<JwtPayload>(this.jwt).role == ADMINISTRATOR_ROLE_NAME;
    }
}

const ADMINISTRATOR_ROLE_NAME = "Administrator";

interface JwtPayload extends JwtPayloadBase {
    role: string;
}
