import React from 'react';
import { useAuth } from '../contexts/AuthContext';
import "../index.css"

export function LoginForm() {
    const { login } = useAuth();

    const handleLogin = (event) => {
        event.preventDefault();
        const email = event.target.email.value;
        const password = event.target.password.value;
        login(email, password);
    };

    return (
        <form id="search-form" role="search" onSubmit={handleLogin}>
            <input
                id="email"
                className=""
                aria-label="Email"
                placeholder="Email"
                type="email"
                name="email"
            />
            <input
                id="password"
                className=""
                aria-label="Password"
                placeholder="Password"
                type="password"
                name="password"
            />
            <button type="submit">Login</button>
        </form>
    );
}
