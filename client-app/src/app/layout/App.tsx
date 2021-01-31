import React from 'react';
import HomePage from '../../features/home/HomePage';
import { Toaster } from 'react-hot-toast';

function App () {
  return (
    <div className="App">
      <Toaster />
      <HomePage/>
    </div>
  );
}

export default App;
