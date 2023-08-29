import React, { useEffect } from 'react';
import Layout from './containers/Layout';
import Navigator from './containers/Navigator';
import { useDispatch } from 'react-redux';
import { session, SessionState } from './features/session/sessionSlice';

const setCookie = (cookie: any, dispatch: Function) => {
  console.log(cookie)
  try {
    JSON.parse(cookie);
    dispatch(session(JSON.parse(cookie)));
    console.log("success")
  } catch (e) {
    dispatch(session({
      email: "null",
      name: "null",
      surrname: "null",
      token: "null"
    }))
  }
}

function App() {
  const dispatch = useDispatch();

  useEffect(() => {
    setCookie(document.cookie.slice(5), dispatch)
  }, [])

  return (
    <Layout>
      <Navigator />
    </Layout>
  );
}

export default App;
