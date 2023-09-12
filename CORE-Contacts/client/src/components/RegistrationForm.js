import React from 'react';
import { useAuth } from '../contexts/AuthContext';

export function RegistrationForm() {
    const { register } = useAuth();

    const handleRegister = (event) => {
        event.preventDefault();
        const email = event.target.email.value;
        const password = event.target.password.value;
        register({ email, password });
    };

    return (
        <div id="detail">
        <form id="contact-form" role="search" onSubmit={handleRegister}>
                <label>
                <span>First Name: </span>
                <input
                id="firstName"
                className=""
                aria-label="FirstName"
                placeholder="  - Alex -"
                type="firstName"
                name="firstName"
                    />
                </label>
                <label>
                    <span>Last Name: </span>
            <input
                id="lastName"
                className=""
                aria-label="LastName"
                placeholder="  - Doe -"
                type="lastName"
                name="lastName"
                    />
                </label>
                <label>
                <span>Email: </span>
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
                    <span>Password: </span>
            <input
                id="password"
                className=""
                aria-label="Password"
                placeholder="  - examplePassword1! -"
                type="password"
                name="password"
                    />
                </label>
            <button type="submit">Register</button>
            </form>
        </div>
    );
}
