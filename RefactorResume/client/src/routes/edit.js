import React, { useState } from 'react';
import { Form, useNavigate, useLoaderData, redirect } from "react-router-dom";
import { updateContact } from "../contacts.js";
import { useAuth } from "../contexts/AuthContext.js";

export async function action({ request, params }) {
    const formData = await request.formData();
    const updates = Object.fromEntries(formData);
    await updateContact(params.contactId, updates);
    return redirect(`/contacts/${params.contactId}`);
}

export default function EditContact() {
    const { userId } = useAuth();
    const { contact } = useLoaderData();
    const navigate = useNavigate();

    // Local state for favorite status
    const [isFavorite, setIsFavorite] = useState(contact.isFavorite);

    // Function to handle Save
    const handleSave = async () => {
        const formElement = document.getElementById('contact-form');
        const formData = new FormData(formElement);
        const updates = Object.fromEntries(formData);

        // Merge favorite status into updates
        updates.isFavorite = isFavorite;

        await updateContact(contact.id, updates);
        navigate(`/contacts/${contact.id}`);
    };

    // Function to handle Cancel
    const handleCancel = () => {
        setIsFavorite(contact.isFavorite); // Reset to original state
        navigate(-1);
    }

    return (
        <Form method="post" id="contact-form">
            <p>
                <input
                    hidden
                    aria-label="ID"
                    type="number"
                    name="id"
                    defaultValue={contact.id}
                />
            </p>
            <p>
                <input
                    hidden
                    aria-label="UserID"
                    type="number"
                    name="userId"
                    defaultValue={userId}
                />
            </p>
            <p>
                <span>Name</span>
                <input
                    placeholder="First"
                    aria-label="First name"
                    type="text"
                    name="firstName"
                    defaultValue={contact.firstName}
                />
                <input
                    placeholder="Last"
                    aria-label="Last name"
                    type="text"
                    name="lastName"
                    defaultValue={contact.lastName}
                />
            </p>
            <label>
                <span>Email</span>
                <input
                    placeholder="email@example.com"
                    aria-label="email"
                    type="text"
                    name="email"
                    defaultValue={contact.email}
                />
            </label>
            <label>
                <span>Twitter</span>
                <input
                    type="text"
                    name="twitterUsername"
                    placeholder="@jack"
                    defaultValue={contact.twitterUsername}
                />
            </label>
            <label>
                <span>Profile Image URL</span>
                <input
                    placeholder="https://example.com/avatar.jpg"
                    aria-label="Profile Image URL"
                    type="text"
                    name="imageUrl"
                    defaultValue={contact.imageUrl}
                />
            </label>
            <label>
                <span>Notes</span>
                <textarea
                    name="note"
                    defaultValue={contact.note}
                    rows={6}
                />
            </label>
            <label>
                <span>Favorite</span>
                <button
                    type="button"
                    onClick={() => setIsFavorite(!isFavorite)} // Toggle local state
                >
                    {isFavorite ? "★" : "☆"}
                </button>
            </label>
            <p>
                <button type="button" onClick={handleSave}>Save</button>
                <button type="button" onClick={handleCancel}>Cancel</button>
            </p>
        </Form>
    );
}