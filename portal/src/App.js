/* eslint-disable */
import './App.css';
import { useEffect, useState } from 'react';
import SearchBar from './components/searchBar';
import ContractsTable from './components/contractsTable';
import ContractDetailPopUp from './components/contractDetailPopUp';

function App() {
  const [contracts, setContracts] = useState(null);
  const [isOpen, setIsOpen] = useState(false);
  const [selectedContract, setSelectedContract] = useState(null);
 
  const togglePopup = (id) => {
    if (id != null){
      Get(id);
    }
    else{
      setIsOpen(false);
    }
  }

  const GetAll = () => {
    fetch("https://localhost/contracts").then(res => res.json()).then(
      (result) => {setContracts(result),
      (error) => {}})
  }

  const Search = (keyword) => {
    fetch("https://localhost/contracts/search?keyword=" + keyword).then(res => res.json()).then(
      (result) => {setContracts(result),
      (error) => {}})
  }

  const Get = (id) => {
    fetch("https://localhost/contracts/get/" + id).then(res => res.json()).then(
      (result) => {setSelectedContract(result),
      (error) => {}})
  }

  useEffect(() => {
    if (isOpen == false && selectedContract != null){
      setIsOpen(true);
    }
  }, [selectedContract])  

  useEffect(() => {
    GetAll();
  }, [])

  return (
    <div className="pt-5 container">
      <SearchBar Search={Search} />
      <ContractsTable contracts={contracts} togglePopup={togglePopup} />
      {isOpen && 
      <ContractDetailPopUp 
        contract={selectedContract}
        handleClose={togglePopup}
      />}
    </div>  
  );
}

export default App;
