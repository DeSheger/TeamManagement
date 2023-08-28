import React, { useEffect } from 'react';
import Layout from './containers/Layout';
import Navigator from './containers/Navigator';
import { useDispatch } from 'react-redux';
import { session } from './features/session/sessionSlice';


function App() {
  const dispatch = useDispatch();
  const cookieData = JSON.parse(document.cookie.slice(5));

  useEffect(() =>{
    dispatch(session(cookieData))
  },[])

  return (
    <Layout>
      <Navigator />
    </Layout>
  );
}

export default App;
