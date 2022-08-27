import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Dashboard from './pages/Dashboard'
import Salas from './pages/Salas'

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/salas" element={<Salas />} />
      </Routes>
    </Router>
  );
}

export default App;
