import { createSlice } from "@reduxjs/toolkit";


export interface userState {
    logged: boolean;
    token: null|string;
    user: any
  }
  
  const initialState: userState = {
    logged: false,
    token: null,
    user: null
  };

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers:{

    }
})