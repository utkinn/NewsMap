import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import { DialogContent, DialogTitle } from '@mui/material';

export const LogIn = ({setLogIn, close}: {setLogIn: any, close:()=> void})=>{
    const handleClick= () =>{
        setLogIn(false)
    }
    return(
        <div className='auth-form'>
            <div className='text-block'>
                <DialogTitle> Вход </DialogTitle>
                <DialogContent> У вас ещё нету учётной записи? <a href="#" onClick={handleClick}>Создайте её</a> </DialogContent>
            </div>
            <TextField label="email" variant='outlined' ></TextField>
            <TextField label="Пароль" type="password" variant='outlined'></TextField>
            <button className="auth-button" onClick={close}> Войти</button>
        </div>
    )
}