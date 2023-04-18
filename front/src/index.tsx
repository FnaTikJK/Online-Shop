import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import RegisterAuth from "./Pages/RegisterAuth/RegisterAuth";

export const baseUrl = 'https://localhost:7055/api/';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
    <App />
);
