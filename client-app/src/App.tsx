import React, { useEffect } from 'react';
import Layout from './containers/Layout';
import Navigator from './containers/Navigator';
import { useDispatch, useSelector } from 'react-redux';
import { session, SessionState } from './features/session/sessionSlice';
import authenticationService from './services/authenticationService';
import { RootState } from './app/store';
import { setCookie } from './cookies/setCookie';


function App() {
  const dispatch = useDispatch();
  const token = useSelector((state:RootState) => state.session.token)

  useEffect(() => {
    setCookie(document.cookie.slice(5), dispatch)
    authenticationService(token);
  }, [token])

  return (
    <Layout>
      <Navigator />
    </Layout>
  );
}

export default App;
