import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginForm from "./features/auth/components/LoginForm";
import SignUpForm from "./features/auth/components/SignUpForm"; // Assuming you have a SignUpForm component
import HomePage from "./features/home/HomePage";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginForm onSubmit={handleLogin} />} />
        <Route path="/signup" element={<SignUpForm onSubmit={handleSignUp} />} />
      </Routes>
    </Router>
  );
}

const handleLogin = async (credentials: { email: string; password: string }) => {
  console.log("Logging in with", credentials);
};

const handleSignUp = async (credentials: { email: string; password: string; name: string }) => {
  console.log("Signing up with", credentials);
};

export default App;
