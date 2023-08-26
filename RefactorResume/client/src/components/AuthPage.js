import React, { useState } from "react";
import { ScrollableComponent } from "../utils/addFunction.js";
import { LoginForm } from "./LoginForm.js";
import "../index.css"
import { RegistrationForm } from "./RegistrationForm.js";
import logo from "../assets/core-logo.png";

export default function AuthPage() {
    const [showLoginForm, setShowLoginForm] = useState(true);

    return (
        <div id="root" className="main-container">
            <>
                <div id="sidebar">
                    <img src={logo} alt="logo" />
                    <h1>Getting Started</h1>
                    <p>How to login:</p>
                    <ul id="getting-started">
                        <li>
                            Email: alex.doe@example.com
                        </li>
                        <li>
                            Password: password1
                        </li>
                    </ul>
                    <button onClick={() => setShowLoginForm(true)}>Login</button>
                    <button onClick={() => setShowLoginForm(false)}>Register</button>
                </div>
                    <div id="detail">
                        {/*<LoginForm />*/}
                        {showLoginForm ? <LoginForm /> : <RegistrationForm />}
                    </div>
                <div id="right-sidebar">
                </div>
            </>
        </div>
    );
}
