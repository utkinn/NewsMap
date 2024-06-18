import React, { useState } from 'react';
import logo from './logo.svg';

import './App.css';
import { Dialog } from '@mui/material';
import { Authorization } from './components/authorization/Authorization';
import { NewsMap } from './components/map/NewsMap';
import { NewsContainer } from './components/newsContainer/newsContainer';

function App() {
  const [authOpen, setAuthOpen] = useState(true)
  const handleClose = () => setAuthOpen(false)
  return (
    <div className="App">
        <Dialog onClose={handleClose} open={authOpen}>
          <Authorization close={handleClose}/>
        </Dialog>
        <NewsContainer/>
        <NewsMap/>
    </div>
  );
}

export default App;
