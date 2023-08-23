/* eslint-disable no-restricted-globals */
/* eslint-disable react/jsx-no-target-blank */
/* eslint-disable jsx-a11y/alt-text */
////Imports
import { Form, useLoaderData, useFetcher, } from "react-router-dom";
import { getContact, updateContact } from "../contacts.js";

////Action - Update Contact Favorite
export async function action({ request, params }) {
    let formData = await request.formData();
    return updateContact(params.contactId, {
        favorite: formData.get("favorite") === "true",
    });
}

////Loader - contactLoader
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

////Functional Component - Contact
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
                            </>
                        ) : (
                            <i>No Name</i>
                        )}{" "}
                        <Favorite contact={contact} />
                    </h1>

                    {contact.email && (<p>{contact.email}</p>)}

                    {contact.twitterUsername &&
                            <a
                                target="_blank"
                                href={`https://twitter.com/${contact.twitterUsername}`}
                            >
                                {contact.twitterUsername}
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

////Functions
function Favorite({ contact }) {
    const fetcher = useFetcher();

    let favorite = contact.favorite;
    if (fetcher.formData) {
        favorite = fetcher.formData.get("favorite") === "true";
    }

    return (
        <fetcher.Form method="post">
                <button
                    name="favorite"
                    value={favorite ? "false" : "true"}
                    aria-label={
                        favorite
                            ? "Remove from favorites"
                            : "Add to favorites"
                    }
                >
                    {favorite ? "★" : "☆"}
                </button>
        </fetcher.Form>
    );
}