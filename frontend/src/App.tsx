
import './App.css';

import { UserJobs } from './components/UserJobs';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { CreateUserForm } from './components/CreateUserForm';
import { CoffeeShopList } from './components/coffee';
function App() {

  return (
    <Router>
      <Routes>
        <Route path="/userJobs/:userId" element={<UserJobs />} />
        <Route path="/createUser" element={<CreateUserForm />} />
        <Route path="/coffee" element={<CoffeeShopList />} />
      </Routes>

    </Router>
  );
}

export default App;
