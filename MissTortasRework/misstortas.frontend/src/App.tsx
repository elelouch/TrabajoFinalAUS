import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "@/features/auth/pages/LoginPage";
import RegisterPage from "@/features/auth/pages/RegisterPage"; // Assuming you have a SignUpForm component
import HomePage from "@/features/home/HomePage";
import ProductPage from "@/features/products/pages/ProductPage";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/signup" element={<RegisterPage />} />
                <Route path="/products" element={<ProductPage />} />
            </Routes>
        </Router>
    );
}

export default App;
