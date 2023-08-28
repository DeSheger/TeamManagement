import React from 'react';
import Layout from './Layout';
import { useSelector } from 'react-redux';
import { RootState } from '../app/store';

const Home = ({theme}:any) => {
    const session = useSelector((state:RootState) => state.session)
    return (
        <>
            {session.email}
        </>
    );
}

export default Home