import React, { useState, createContext, useContext, useMemo } from "react";
import AuthPage from "../components/AuthPage"; 
import { baseUrl } from '../services/config.js';
import "../index.css"

export const login = (email, password) => {
    const loginUrl = `${baseUrl}/Users/login`;

    return fetch(loginUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            email,
            password,
        }),
    })
        .then((response) => {
            if (!response.ok) {
                throw new Error('Login failed');
            }
            return response.json();
        })
        .then((user) => {
            return user;
        })
        .catch((error) => {
            console.error('An error occurred:', error);
            throw error; // Re-throw error to handle it in the calling code
        });
};

// Create Auth Context
export const AuthContext = createContext();

// Hooks: Authentication Context
export function useAuth() {
    return useContext(AuthContext);
}

// Component: Authentication State Provider
export function AuthProvider({ children }) {
    const [loggedIn, setLoggedIn] = useState(false);
    const [userId, setUserId] = useState(null);

    const isLoggedIn = useMemo(() => !!loggedIn, [loggedIn]);

    const handleLogin = (email, password) => {
        return login(email, password)
            .then((user) => {
                setLoggedIn(true);
                setUserId(user.id);
            });
    };

    //const register = async (userDetails) => {
    //    const response = await fetch("/api/Users/{userId}", {
    //        method: "POST",
    //        headers: { "Content-Type": "application/json" },
    //        body: JSON.stringify(userDetails),
    //    });
    //    const data = await response.json();
    //    if (data.success) {
    //        setLoggedIn(true);
    //        setUserId(data.userId);
    //    }
    //    return data.success;
    //};

    const logout = () => {
        setLoggedIn(false);
        setUserId(null);
    };

    return (
        //<AuthContext.Provider value={{ isLoggedIn, login: handleLogin, register, logout }}>
        <AuthContext.Provider value={{ isLoggedIn, login: handleLogin, logout }}>
            {/*{isLoggedIn ? children : <AuthPage />} */}
            {children} 
        </AuthContext.Provider>
    );
}
