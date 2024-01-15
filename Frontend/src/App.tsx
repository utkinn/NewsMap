import React, {useEffect, useState} from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  const [weatherForecast, setWeatherForecast] = useState<string>("Loading...");

  useEffect(() => {
    fetch(`${process.env.REACT_APP_API_BASE_URL}/WeatherForecast`).then(resp => {
      if (resp.ok) {
        resp.text().then(setWeatherForecast);
      } else {
        resp.text().then(t => setWeatherForecast(`Ошибка ${resp.status}: ${t}`));
      }
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo"/>
        <p>
          {weatherForecast}
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
