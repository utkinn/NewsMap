import React, { useRef, useState } from 'react';
import TextField from '@mui/material/TextField';
import { DialogContent, DialogTitle } from '@mui/material';
import { userLogin } from '../../actions/userAction';
import { useAppDispatch } from '../../app/hooks';

export const LogIn = ({setLogIn, close}: {setLogIn: any, close:()=> void})=>{
    const [email, setEmail]= useState('');
    const [password, setPassword]= useState('');
    const dispatch = useAppDispatch();
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, value } = e.target;
        if (id === 'email') {
            setEmail(value);
        } else if (id === 'password') {
            setPassword(value);
        }
    }
    const handleClick= () =>{
        setLogIn(false)
    }
    return(
        <div className='auth-form'>
            <div className='text-block'>
                <DialogTitle> Вход </DialogTitle>
                <DialogContent> У вас ещё нету учётной записи? <a href="#" onClick={handleClick}>Создайте её</a> </DialogContent>
            </div>
            <TextField id='email' onChange={handleChange} label="email" variant="filled" ></TextField>
            <TextField id='password' onChange={handleChange} label="Пароль" type="password" variant="filled"></TextField>
            <button className="auth-button" onClick={() => {
                dispatch(userLogin({email, password, close}));
                }}> Войти</button>
        </div>
    )
}