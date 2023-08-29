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
        <div id="login-detail">
            <section id="contact-form">
            <form id="login-form" onSubmit={handleLogin}>
                <label>
                <span>Email</span>
                <input
                    id="email"
                    className=""
                    aria-label="Email"
                    placeholder="  - email@example.com -"
                    type="email"
                    name="email"
                    />
                </label>
                <label>
                <span>Password</span>
                <input
                    id="password"
                    className=""
                    aria-label="Password"
                    placeholder="  - examplePassword1! -"
                    type="password"
                    name="password"
                    />
                </label>
                <button type="submit">Login</button>
                </form>
            </section>
        </div>
    );
}
