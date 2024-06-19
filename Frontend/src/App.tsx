import React, { useEffect, useState } from 'react';
import logo from './logo.svg';

import './App.scss';
import { Dialog } from '@mui/material';
import { Authorization } from './components/authorization/Authorization';
import { NewsMap } from './components/map/NewsMap';
import { NewsContainer } from './components/newsContainer/newsContainer';
import { SearchNewsPanel } from './components/searchNewsPanel/searchNewsPanel';
import { ToastContainer } from 'react-toastify';
import { useAppDispatch } from './app/hooks';
import { FetchNews } from './actions/newsAction';
import 'react-toastify/dist/ReactToastify.css';
function App() {
  const [authOpen, setAuthOpen] = useState(true)
  const handleClose = () => setAuthOpen(false)
  return (
    <div className="App">
        <ToastContainer position="top-right"
autoClose={5000}
hideProgressBar={false}
newestOnTop={false}
closeOnClick
rtl={false}
pauseOnFocusLoss
draggable
pauseOnHover
theme="light"
/>
        <Dialog className='auth-dialog' onClose={handleClose} open={authOpen} PaperProps={{ sx: { borderRadius: "16px", background: "#E2E3DE" } }}>
          <Authorization close={handleClose}/>
        </Dialog>
        <NewsContainer/>
        <SearchNewsPanel/>
        <NewsMap/>
    </div>
  );
}

export default App;
