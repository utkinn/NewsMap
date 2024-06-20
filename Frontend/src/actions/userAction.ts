import {toast} from "react-toastify";
import {AppDispatch} from "../app/store";
import {login} from "../slices/userSlice";


export const userLogin = ({email, password, close}: {
    email: string,
    password: string,
    close: () => void
}) => async (dispatch: AppDispatch) => {
    console.log("Мы здесь")
    try {
        const response = await fetch('/api/Auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: email,
                password: password
            })
        })
        if (!response.ok) {
            throw new Error(response.statusText);
        }

        const data = await response.json();
        dispatch(login({token: data.token, userName: data.userName}));
        close();
    } catch (err: any) {
        toast.error(err.toString())
    }
}

export const userRegistration = ({userName, email, password, close}: {
    userName: string,
    email: string,
    password: string,
    close: () => void
}) => async (dispatch: AppDispatch) => {
    try {
        const response = await fetch('/api/Auth/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                firstName: userName,
                lastName: "",
                email: email,
                password: password,
                subscribeToUpdates: true
            })
        })
        if (!response.ok) {
            if (response.status == 400) {
                response.json().then(body => {
                    toast.error(body.detail);
                });
                return;
            }
            throw new Error(response.statusText);
        }
        const data = await response.json();
        dispatch(login({token: data.token, userName: userName}));
        close();
    } catch (err: any) {
        toast.error(err.toString())
    }
}