import {useLocalStorage} from "@uidotdev/usehooks";
import {useEffect, useState} from "react";
import {httpClient} from "../httpClient";
import {Profile} from "./Profile";

export function useProfile(): [Profile | null, boolean] {
    const jwt = localStorage.getItem("jwt");
    const [profile, setProfile] = useState<Profile | null>(null);
    const [ready, setReady] = useState(false);

    useEffect(() => {
        if (!jwt) {
            setReady(true);
            return;
        }
        httpClient
            .get<Profile>("/Profile")
            .then(p => {
                setProfile(p.data);
                setReady(true);
            })
    }, [jwt]);

    return [profile, ready];
}
