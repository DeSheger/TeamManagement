import React from 'react';
import Layout from './containers/Layout';
import Start from './containers/Start';
import Navigator from './containers/Navigator';
import Menu from './components/Menu';


function App() {
  return (
    <Layout>
      <Navigator />
      <Menu />
    </Layout>
  );
}

export default App;
