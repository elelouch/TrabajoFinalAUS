import React from "react";
import COOKIES from "shared/constants/constants";


const getUsernameFromCookie = (): string | null => {
  const cookies = document.cookie.split("; ");
  const usernameCookie = cookies.find((cookie) => cookie.startsWith(COOKIES.USERNAME));
  return usernameCookie ? decodeURIComponent(usernameCookie.split("=")[1]) : null;
};

const Dashboard: React.FC = () => {
  const username = getUsernameFromCookie();

  return (
    <div className="flex items-center justify-center h-screen">
      <h1 className="text-4xl font-bold">
        {username ? `Hello, ${username}` : "Hello, Guest"}
      </h1>
    </div>
  );
};

export default Dashboard;