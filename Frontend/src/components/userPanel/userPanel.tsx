import React, { useState } from "react";
import { useAppDispatch, useAppSelector } from "../../app/hooks";
import {ReactComponent as EmptyUserIcon} from "../../icons/emptyUser.svg";
import {ReactComponent as PepeUserIcon} from "../../icons/pepeUser.svg";
import {ReactComponent as SettingsIcon} from "../../icons/settings.svg";
import {ReactComponent as LogOutIcon} from "../../icons/logOut.svg";
import {Dialog} from '@mui/material';
import { logout } from "../../slices/userSlice";
import './userPanel.scss';
import { UserSettings } from "./userSettings";

export const UserPanel = ({setAuthOpen}: {setAuthOpen : any}) => {
    const user = useAppSelector(state => state.user);
    const [openSetting, setOpenSettings] = useState(false);
    const dispatch = useAppDispatch();
    return (
        
            <div className="user-panel">
                {!user.logged ? <React.Fragment> <EmptyUserIcon/> <button onClick={() => setAuthOpen(true)}>Войти</button> </React.Fragment> : 
                <React.Fragment> <div className="user-panel-info">{user.userName === "Ender" ? <PepeUserIcon/>: <EmptyUserIcon/>} <p>{user.userName}</p></div>  <SettingsIcon className="clickable" onClick={() => setOpenSettings(true)}/> <LogOutIcon className="clickable" onClick={() => dispatch(logout())}/></React.Fragment>}
                <Dialog open={openSetting} onClose={() => setOpenSettings(false) } PaperProps={{sx: {borderRadius: "16px", background: "#E2E3DE", maxWidth: "none"}}}>
                    <UserSettings close={setOpenSettings}/>
                </Dialog>
            </div>
            
        
    );
}