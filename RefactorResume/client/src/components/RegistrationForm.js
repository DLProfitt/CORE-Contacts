//import React from 'react';
//import { useAuth } from '../contexts/AuthContext';

//export function RegistrationForm() {
//    const { register } = useAuth();

//    const handleRegister = (event) => {
//        event.preventDefault();
//        const email = event.target.email.value;
//        const password = event.target.password.value;
//        register({ email, password });
//    };

//    return (
//        <form id="search-form" role="search" onSubmit={handleRegister}>
//            <input
//                id="firstName"
//                className=""
//                aria-label="FirstName"
//                placeholder="FirstName"
//                type="firstName"
//                name="firstName"
//            />
//            <input
//                id="lastName"
//                className=""
//                aria-label="LastName"
//                placeholder="LastName"
//                type="lastName"
//                name="lastName"
//            />
//            <input
//                id="email"
//                className=""
//                aria-label="Email"
//                placeholder="Email"
//                type="email"
//                name="email"
//            />
//            <input
//                id="password"
//                className=""
//                aria-label="Password"
//                placeholder="Password"
//                type="password"
//                name="password"
//            />
//            <button type="submit">Register</button>
//        </form>
//    );
//}
