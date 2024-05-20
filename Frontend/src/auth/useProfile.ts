import {useLocalStorage} from "@uidotdev/usehooks";
import {useEffect, useState} from "react";
import {httpClient} from "../httpClient";
import {Profile} from "./Profile";

export function useProfile(): [Profile | null, boolean] {
    const [jwt,] = useLocalStorage("jwt", null);

    if (!jwt) {
        return [null, true];
    }

    const [profile, setProfile] = useState<Profile | null>(null);
    const [ready, setReady] = useState(false);

    useEffect(() => {
        httpClient
            .get<Profile>("/Profile")
            .then(p => {
                setProfile(p.data);
                setReady(true);
            })
    }, []);
    
    return [profile, ready];
}
