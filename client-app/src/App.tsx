import React, { useEffect, useState } from 'react';
import Layout from './containers/Layout';
import Navigator from './containers/Navigator';
import { useDispatch, useSelector } from 'react-redux';
import authenticationService from './services/authenticationService';
import { RootState } from './app/store';
import { setCookie } from './cookies/setCookie';


function App() {

  const dispatch = useDispatch();
  const token = useSelector((state:RootState) => state.session.token);
  const [authentication, setAuthentication] = useState(false);

  useEffect(() => {

    setCookie(document.cookie.slice(5), dispatch);

    authenticationService(token)
      .then((val) => setAuthentication(val))
      .catch((val) => setAuthentication(val));

    console.log(authentication);
  }, [token, authentication])

  return (
    <Layout>
      <Navigator />
    </Layout>
  );
}

export default App;
