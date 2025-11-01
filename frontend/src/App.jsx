import { Route, Routes } from "react-router-dom";
import SignUpPage from "./pages/account/SignUpPage";
import SignInPage from "./pages/account/SignInPage";
import "./App.css";
import UserTaskPage from "./pages/Task/UserTaskPage";

function App() {
  return (
    <Routes>
      <Route path="/" element={<SignInPage />} />
      <Route path="/sign-up" element={<SignUpPage />} />
      <Route path="/tasks" element={<UserTaskPage />} />
    </Routes>
  );
}

export default App;
