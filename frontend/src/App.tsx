import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { CreateUserComponent } from './components/CreateUserForm';

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/createUser" element={<CreateUserComponent />} />
      </Routes>

    </Router>
  );
}

export default App;
