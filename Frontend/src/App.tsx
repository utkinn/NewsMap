import React, { useState } from 'react';
import logo from './logo.svg';

import './App.scss';
import { Dialog } from '@mui/material';
import { Authorization } from './components/authorization/Authorization';
import { NewsMap } from './components/map/NewsMap';
import { NewsContainer } from './components/newsContainer/newsContainer';
import { SearchNewsPanel } from './components/searchNewsPanel/searchNewsPanel';

function App() {
  const [authOpen, setAuthOpen] = useState(true)
  const handleClose = () => setAuthOpen(false)
  return (
    <div className="App">
        <Dialog className='auth-dialog' onClose={handleClose} open={authOpen} PaperProps={{ sx: { borderRadius: "16px", background: "#E2E3DE" } }}>
          <Authorization close={handleClose}/>
        </Dialog>
        <NewsContainer/>
        <SearchNewsPanel/>
        <NewsMap/>
    </div>
}

xport default App;
