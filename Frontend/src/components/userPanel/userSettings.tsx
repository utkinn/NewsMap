import React, { useState } from "react";
import {ReactComponent as ProfileIcon} from "../../icons/profile.svg";
import {ReactComponent as SettingsIcon} from "../../icons/addSettings.svg";

export const UserSettings = () => {
    const [openProfileSettings, setOpenProfileSettings] = useState(true);
    return (
        <div className="user-settings">
            <div className="user-settings-choose">
                <div className="user-settings-header"><span> Настройки </span></div>
                <button className={ openProfileSettings ? "user-settings-active" : ""} onClick={() => setOpenProfileSettings(true)}> <ProfileIcon/><span>Профиль</span></button>
                <button className={ !openProfileSettings ? "user-settings-active" : ""} onClick={() => setOpenProfileSettings(false)}> <SettingsIcon/><span>Другие</span></button>
            </div>
            <div className="user-settings-change">

            </div>
        </div>
    )
}