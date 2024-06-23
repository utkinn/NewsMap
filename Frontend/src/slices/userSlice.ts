import { createSlice } from "@reduxjs/toolkit";


export interface userState {
    logged: boolean;
    token: null|string;
    userName: string;
    email: string;
  }
  
  const initialState: userState = {
    logged: false,
    token: null,
    userName: "",
    email: ""
  };

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers:{
        login: (state, action) => {
            state.logged = true;
            state.token = action.payload.token;
            state.userName = action.payload.userName;
            state.email = action.payload.email;
        },
        logout: (state) => {
            state.logged = false;
            state.token = null;
            state.userName = "";
            state.email = "";
        }
    }
})

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;