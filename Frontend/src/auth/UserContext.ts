import {createContext} from "react";
import {User} from "./User";

export const UserContext = createContext<User | null>(null);