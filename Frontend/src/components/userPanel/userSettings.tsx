import React, { useState } from "react";
import {ReactComponent as ProfileIcon} from "../../icons/profile.svg";
import {ReactComponent as SettingsIcon} from "../../icons/addSettings.svg";
import {ReactComponent as PepeIcon} from "../../icons/pepeUser.svg";
import {ReactComponent as EmptyUserIcon} from "../../icons/emptyUser.svg";
import { useAppSelector } from "../../app/hooks";
import TextField from '@mui/material/TextField';
import { Button } from "@mui/material";

export const UserSettings = ({close} : {close: any}) => {
    const [openProfileSettings, setOpenProfileSettings] = useState(true);
    const user = useAppSelector(state => state.user);
    const [userName, setUserName] = useState(user.userName);
    const [userEmail, setUserEmail] = useState(user.email);
    console.log(close);
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, value } = e.target;
        switch (id) {
            case 'userName':
                setUserName(value);
                break;
            case 'email':
                setUserEmail(value);
                break;
        }
    }
    return (
        <div className="user-settings">
            <div className="user-settings-choose">
                <div className="user-settings-header"><span> Настройки </span></div>
                <button className={ openProfileSettings ? "user-settings-active" : ""} onClick={() => setOpenProfileSettings(true)}> <ProfileIcon/><span>Профиль</span></button>
                <button className={ !openProfileSettings ? "user-settings-active" : ""} onClick={() => setOpenProfileSettings(false)}> <SettingsIcon/><span>Другие</span></button>
            </div>
            <div className="user-settings-change">
                {openProfileSettings ? 
                <>
                <div className="user-settings-header">
                    <span> Профиль </span>
                </div>
                {user.userName === "Ender" ? <PepeIcon/> : <EmptyUserIcon/>} 
                <TextField id="userName" onChange={handleChange} value={userName} label="Имя пользователя" variant="filled" style = {{width: "40%", margin: "15px"}}></TextField>
                <TextField id="email" onChange={handleChange} value={userEmail} label="Email" variant="filled" style = {{width: "40%", margin: "15px"}}></TextField>
                <Button className="user-settings-button" onClick={() => close(false)}> Сохранить</Button>
                </>
                
                : <div className="user-settings-header"><span> Другие настройки </span></div>}
                
            </div>
        </div>
    )
}