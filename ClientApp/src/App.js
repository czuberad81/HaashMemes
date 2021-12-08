import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Home from './components/Home';
import './custom.css'

function App() {
  return (
    <Router>
      <Route exact path='/' component={Home} />
    </Router>
  );
}
export default App;

