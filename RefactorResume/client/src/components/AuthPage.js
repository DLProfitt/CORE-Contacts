import React, { useState } from "react";
import { ScrollableComponent } from "../utils/addFunction.js";
import { LoginForm } from "./LoginForm.js";
import "../index.css"
//import { RegistrationForm } from "./RegistrationForm.js";

export default function AuthPage() {
    const [showLoginForm, setShowLoginForm] = useState(true);

    return (
        <div>
            <div id="sidebar">
                <h1>Refactor(Resume)</h1>
            </div>
            <ScrollableComponent>
                <div id="detail">
                    <LoginForm />
                {/*    {showLoginForm ? <LoginForm /> : <RegistrationForm />}*/}
                </div>
            </ScrollableComponent>
            <div id="right-sidebar">
                <h1>Login</h1>
                <button onClick={() => setShowLoginForm(true)}>Login</button>
            {/*    <button onClick={() => setShowLoginForm(false)}>Register</button>*/}
            </div>
        </div>
    );
}
