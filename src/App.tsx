import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './Layout';
import Home from './components/Home';
import Test from './components/Test';

function App() {

  return (
    <>
      <Router>
      <Layout>
      <Routes>
      </Routes>
      </Layout>
    </Router>
     
    </>
  )
}

export default App
