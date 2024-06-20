import React from "react";
import { useAppSelector } from "../../app/hooks";
import {ReactComponent as EmptyUserIcon} from "../../icons/emptyUser.svg";

export const UserPanel = () => {
    const logged = useAppSelector(state => state.user.logged);
    return (
        <div>
            {!logged ? <React.Fragment> <EmptyUserIcon/> <button>Войдите</button> </React.Fragment> : <div></div>}
        </div>
    );
}