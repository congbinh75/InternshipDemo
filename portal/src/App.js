/* eslint-disable */
import logo from './logo.svg';
import './App.css';
import SearchBar from './components/searchBar';
import { useEffect, useState } from 'react';

function App() {
  const [data, setData] = useState(null);

  const Search = (keyword) => {

  }

  useEffect(() => {

  }, [])

  useEffect(() => {

  }, [data])

  return (
    <div class="pt-5 container">
      <SearchBar />
    </div>  
  );
}

export default App;
