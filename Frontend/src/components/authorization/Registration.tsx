import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import { DialogContent, DialogTitle } from '@mui/material';

export const Registration = ({setLogIn, close}: {setLogIn: any, close:any})=>{
    const handleClick= () =>{
        setLogIn(true)
    }
    return(
        <div className='auth-form'>
            <div className='text-block'>
                <DialogTitle> Регистрация </DialogTitle>
                <DialogContent> У вас уже есть учётная запись? <a href="#" onClick={handleClick}>Войдите в неё</a></DialogContent>
            </div>
            <TextField label="Имя пользователя" variant='outlined' ></TextField>
            <TextField label="email" variant='outlined' ></TextField>
            <TextField label="Пароль" type="password" variant='outlined'></TextField>
            <TextField label="Пароль ещё раз" variant='outlined'></TextField>
            <button className="auth-button" onClick={close}> Зарегистрироваться </button>
        </div>
    )
}