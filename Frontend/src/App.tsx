import React, {useState} from 'react';
import logo from './logo.svg';
import './App.css';
import {useProfile} from "./auth/useProfile";
import {login} from "./auth/login";
import {AxiosError} from "axios";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo"/>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>

                <UserTest/>
            </header>
        </div>
    );
}

function UserTest() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [profile, profileReady] = useProfile();

    async function handleLogin() {
        try {
            await login(email, password);
        } catch (e) {
            console.error(e);
            const err = e as AxiosError;
            if (err.response!.status === 401) {
                alert("Неправильный логин или пароль");
            }
            return;
        }
        window.location.reload();
    }

    async function handleLogout() {
        localStorage.removeItem("jwt");
        window.location.reload();
    }

    if (!profileReady) {
        return <p>Загрузка...</p>;
    }

    if (!profile) {
        return <div>
            <input placeholder="Email" value={email} onChange={e => setEmail(e.target.value)}/>
            <input placeholder="Password" value={password} onChange={e => setPassword(e.target.value)}/>
            <button onClick={handleLogin}>Войти</button>
        </div>
    }

    return <div>
        Hello, {profile.isAdmin ? "Администратор" : `${profile.firstName} ${profile.lastName}`}!
        <br/>
        <button onClick={handleLogout}>log out</button>
    </div>
}

export default App;
