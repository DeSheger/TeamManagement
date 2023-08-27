import { createSlice, PayloadAction } from '@reduxjs/toolkit';


export interface SessionState {
    email: string,
    name: string,
    surrname: string,
    token: string
};

const initialState:SessionState = {
    email: "null",
    name: "null",
    surrname: "null",
    token: "null"
};

export const sessionSlice = createSlice({
    name: 'counter',
    initialState,
    reducers: {
      session: (state, action: PayloadAction<SessionState>) => {
        state = action.payload
      },
    },
  })

export const {session} = sessionSlice.actions;
export default sessionSlice.reducer;