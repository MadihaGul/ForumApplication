import React from 'react';
import logo from './logo.svg';
import './App.css';
import Header from './Header';
import PostTable from '../post/PostTable';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import PostDetail from '../post/PostDetail';
import PostAdd from '../post/PostAdd';
import PostEdit from '../post/PostEdit';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <Header subtitle="Enjoy Forum Application"/>
      <Routes>
        <Route path='/' element = {<PostTable/>}/>
        <Route path="/api/Posts/:id" element={<PostDetail />}/>
        <Route path="/api/Posts/add" element={<PostAdd />}/>
        <Route path="/api/Posts/edit/:id" element={<PostEdit />}/>

        

      </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
