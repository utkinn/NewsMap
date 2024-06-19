import React from "react";
import { useAppSelector } from "../../app/hooks";

export const UserPanel = () => {
    const logged = useAppSelector(state => state.user.logged);
    return (
        <div>
            
        </div>
    );
}