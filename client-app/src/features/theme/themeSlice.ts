import { createSlice } from "@reduxjs/toolkit"

export interface ThemeSlice
{
    theme: string
}

const initialState = {
    theme: "light"
}

const themeSlice = createSlice({
    name: "theme",
    initialState,
    reducers: {
        light: (state) => {state.theme = "light"},
        dark: (state) => {state.theme = "dark"} 
    }
})

export const {light, dark} = themeSlice.actions;

export default themeSlice.reducer;