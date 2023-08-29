import { Form, useNavigate, redirect } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext.js";
import { createContact } from "../contacts.js";
import { getUser } from "../utils/users.js";

export async function action({ request }) {
    const contactData = await request.formData();
    const contact = {
        userID: contactData.get('userId'),
        firstName: contactData.get('firstName'),
        lastName: contactData.get('lastName'),
        email: contactData.get('email'),
        twitterUsername: contactData.get('twitterUsername'),
        imageUrl: contactData.get('imageUrl'),
        note: contactData.get('note'),
    };
    await createContact(contact);
    return redirect(`/`);
}

export async function loader() {
    const userData = await getUser(1);
    console.log("User Data: " + userData);
    return { userData };
}

export default function CreateContact() {
    const { userId } = useAuth();
    const navigate = useNavigate();

    return (
        <Form method="post" id="contact-form">
            <p>
                <input
                    hidden
                    aria-label="ID"
                    type="number"
                    name="id"
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
                <label id="name-fields">
                    <span>Name</span>
                    <formgroup className="name-fields">
            <div className="name-fields">
                <input
                    placeholder="First"
                    aria-label="First name"
                    type="text"
                    name="firstName"
                />
                <input
                    placeholder="Last"
                    aria-label="Last name"
                    type="text"
                    name="lastName"
                        />
            </div>
                    </formgroup>
                </label>
            <label>
                <span>Email</span>
                <input
                    placeholder="email@example.com"
                    aria-label="email"
                    type="text"
                    name="email"
                />
            </label>
            <label>
                <span>Twitter</span>
                <input
                    type="text"
                    name="twitterUsername"
                    placeholder="@jack"
                />
            </label>
            <label>
                <span>Profile Image</span>
                <input
                    placeholder="https://example.com/avatar.jpg"
                    aria-label="Profile Image URL"
                    type="text"
                    name="imageUrl"
                />
            </label>
            <label>
                <span>Notes</span>
                <textarea
                    name="note"
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
