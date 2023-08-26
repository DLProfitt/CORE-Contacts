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
            <p>
                <button type="submit">Save</button>
                <button type="button" onClick={() => {
                    navigate(-1);
                }}>Cancel</button>
            </p>
        </Form>
    );
}