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
        note: contactData.get('note'),
        imageUrl: contactData.get('imageUrl'),
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
                />
                <input
                    placeholder="Last"
                    aria-label="Last name"
                    type="text"
                    name="lastName"
                />
            </p>
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
                <span>Notes</span>
                <textarea
                    type="text"
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
