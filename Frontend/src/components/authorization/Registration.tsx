import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import { DialogContent, DialogTitle } from '@mui/material';
import { useAppDispatch } from '../../app/hooks';
import { userRegistration } from '../../actions/userAction';

export const Registration = ({setLogIn, close}: {setLogIn: any, close:any})=>{
    const [userName, setUserName] = useState('');
    const [email, setEmail]= useState('');
    const [password, setPassword]= useState('');
    const [passwordAgain, setPasswordAgain]= useState('');
    const dispatch = useAppDispatch();

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { id, value } = e.target;
        switch (id) {
            case 'userName':
                setUserName(value);
                break;
            case 'email':
                setEmail(value);
                break;
            case 'password':
                setPassword(value);
                break;
            case 'passwordAgain':
                setPasswordAgain(value);
                break;
        }
    }
    const handleClick= () =>{
        setLogIn(true)
    }
    return(
        <div className='auth-form'>
            <div className='text-block'>
                <DialogTitle> Регистрация </DialogTitle>
                <DialogContent> У вас уже есть учётная запись? <a href="#" onClick={handleClick}>Войдите в неё</a></DialogContent>
            </div>
            <TextField onChange={handleChange} id='userName' label="Имя пользователя" variant="filled" ></TextField>
            <TextField onChange={handleChange} id='email' label="email" variant="filled" ></TextField>
            <TextField onChange={handleChange} id='password' label="Пароль" type="password" variant="filled"></TextField>
            <TextField onChange={handleChange} id='passwordAgain' label="Пароль ещё раз" variant="filled"></TextField>
            <button className="auth-button" onClick={()=>{
              dispatch(userRegistration({userName, email, password, close}))  
            }}> Создать учётную запись </button>
        </div>
    )
}