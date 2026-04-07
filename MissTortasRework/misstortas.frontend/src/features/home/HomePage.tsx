import React from "react";
import { Link } from "react-router-dom";

const HomePage: React.FC = () => {
  return (
    <div style={{ textAlign: "center", padding: "2rem" }}>
      <h1>Welcome to Miss Tortas!</h1>
      <p>Your one-stop shop for delicious cakes and desserts.</p>

      <div style={{ marginTop: "2rem" }}>
        <Link to="/login" style={{ marginRight: "1rem" }}>
          <button>Login</button>
        </Link>
        <Link to="/signup">
          <button>Sign Up</button>
        </Link>
      </div>
    </div>
  );
};

export default HomePage;