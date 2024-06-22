import { createSlice } from "@reduxjs/toolkit";


export interface userState {
    logged: boolean;
    token: null|string;
    userName: string
  }
  
  const initialState: userState = {
    logged: false,
    token: null,
    userName: "Ender"
  };

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers:{
        login: (state, action) => {
            state.logged = true;
            state.token = action.payload.token;
            state.userName = action.payload.userName;
        },
        logout: (state) => {
            state.logged = false;
            state.token = null;
            state.userName = "";
        }
    }
})

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;