import { Route, Routes } from 'react-router-dom';
import SignUpPage from './pages/account/SignUpPage';
import SignInPage from './pages/account/SignInPage';
import './App.css'

function App() {
  return (
<Routes>
  <Route path="/" element={<SignInPage />} />
  <Route path="/sign-up" element={<SignUpPage />}  />
</Routes>
  );
}

export default App
