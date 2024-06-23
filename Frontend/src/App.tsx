import React, {useState} from 'react';

import './App.scss';
import {Dialog} from '@mui/material';
import {Authorization} from './components/authorization/Authorization';
import {NewsMap} from './components/map/NewsMap';
import {NewsContainer} from './components/newsContainer/newsContainer';
import {SearchNewsPanel} from './components/searchNewsPanel/searchNewsPanel';
import {ToastContainer} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { UserPanel } from './components/userPanel/userPanel';
import { MarkFilter } from './components/markFilter/markFilter';

function App() {
    const [authOpen, setAuthOpen] = useState(false)
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
            <Dialog className='auth-dialog' onClose={handleClose} open={authOpen}
                    PaperProps={{sx: {borderRadius: "16px", background: "#E2E3DE"}}}>
                <Authorization close={handleClose}/>
            </Dialog>
            <NewsContainer/>
            <SearchNewsPanel/>
            <NewsMap/>
            <UserPanel setAuthOpen={setAuthOpen}/>
            <MarkFilter/>
        </div>
    );
}

export default App;
