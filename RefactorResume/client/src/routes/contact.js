/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable react/jsx-no-target-blank */
/* eslint-disable no-restricted-globals */
// Imports
import { Form, useLoaderData, } from "react-router-dom";
import { getContact } from "../contacts.js";

export async function loader({ params }) {
    const contact = await getContact(params.contactId);
    if (!contact) {
        throw new Response("", {
            status: 404,
            statusText: "Not Found",
        });
    }
    return { contact };
}

export default function Contact() {
    const { contact } = useLoaderData();

    return (
        <>
            <div id="contact">
                <div><img key={contact.imageUrl} src={contact.imageUrl} /></div>
                <div>
                    <h1>
                        {contact.firstName || contact.lastName ? (
                            <>
                                {contact.firstName} {contact.lastName}
                                {contact.isFavorite && <span style={{ color: 'yellow' }}> ★</span>}
                            </>
                        ) : (
                            <i>No Name</i>
                        )}
                    </h1>

                    {contact.email && (<p>{contact.email}</p>)}

                    {contact.twitterUsername &&
                        <a
                            target="_blank"
                            href={`https://twitter.com/${contact.twitterUsername}`}
                        >
                            {'@' + contact.twitterUsername}
                        </a>
                    }

                    {contact.note && <p>{contact.note}</p>}

                    <div>
                        <Form action="edit">
                            <button type="submit">Edit</button>
                        </Form>
                        <Form
                            method="post"
                            action="destroy"
                            onSubmit={(event) => {
                                if (
                                    !confirm(
                                        "Please confirm you want to delete this record."
                                    )
                                ) {
                                    event.preventDefault();
                                }
                            }}
                        >
                            <button type="submit">Delete</button>
                        </Form>
                    </div>
                </div>
            </div>
        </>
    );
}