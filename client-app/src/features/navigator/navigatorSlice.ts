import { createSlice } from '@reduxjs/toolkit';
//import type { PayloadAction } from '@reduxjs/toolkit';

export interface NavigatorState
{
    start: boolean,
    home: boolean,
    login: boolean,
    docs: boolean,

    // Authentication require

    profile: boolean,
    activities: boolean,
    companies: boolean,
    groups: boolean,
    users: boolean,
}

const initialState: NavigatorState = {
    start: true,
    home: false,
    login: false,
    docs: false,

    // Authentication require

    profile: false,
    activities: false,
    companies: false,
    groups: false,
    users: false,
}

const iteration = (containerName: string, state: object) => {
    for(let [key,value] of Object.entries(state))
    {
        if(key == containerName)
            value = true;
        else
            value = false;
    };
};

const navigatorSlice = createSlice({
    name: 'navigator',
    initialState,
    reducers: {
        start: (state) => {
            iteration("start", state)
        },
        home: (state) => {
            iteration("home", state)
        },
        login: (state) => {
            iteration("login", state)
        },
        docs: (state) => {
            iteration("docs", state)
        },
        profile: (state) => {
            iteration("profile", state)
        },
        activities: (state) => {
            iteration("activities", state)
        },
        companies: (state) => {
            iteration("companies", state)
        },
        groups: (state) => {
            iteration("groups", state)
        },
        users: (state) => {
            iteration("users", state)
        },
    }
});

export const { start, home, login, docs, profile
    , activities, companies, groups, users} = navigatorSlice.actions;

export default navigatorSlice.reducer;

