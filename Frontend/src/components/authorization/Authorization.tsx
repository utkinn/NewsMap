import React, { useState } from 'react';
import { LogIn } from './LogIn';
import { Registration } from './Registration';
import './auth.scss'

export const Authorization = (close:{close:() => void})=>{
    const [logIn, setLogIn] = useState(true);
    return(
        <React.Fragment>
            {logIn ? <LogIn setLogIn={setLogIn} close={close.close}/> : <Registration setLogIn={setLogIn} close={close.close}/>}
        </React.Fragment>
    )
}
