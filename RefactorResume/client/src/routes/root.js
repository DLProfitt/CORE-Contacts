/* eslint-disable no-restricted-globals */
/* eslint-disable react/jsx-no-target-blank */
////Imports
import { useEffect, } from "react";
import { Outlet, NavLink, useLoaderData, Form, useNavigation, useSubmit, } from "react-router-dom";
import { getContacts, createContact, } from "../contacts";
import { ScrollableComponent } from "../utils/addFunction.js";
import logo from "../assets/COREContacts-Logo.png";
import YourCore from "../assets/COREContacts-YourCORE.png";

////Action - rootAction
export async function action() {
    const contact = await createContact();
    return { contact };
}

////Loader - rootLoader
export async function loader({ request }) {
    const url = new URL(request.url);
    const q = url.searchParams.get("q");
    const contacts = await getContacts(q);
    return { contacts, q };
}

////Functional Component - Root
export default function Root() {
    const { contacts, q } = useLoaderData();
    const navigation = useNavigation();
    const submit = useSubmit();

    const searching =
        navigation.location &&
        new URLSearchParams(navigation.location.search).has("q");

    useEffect(() => {
        document.getElementById("q").value = q;
    }, [q]);

    return (
        <>
            <div id="sidebar" className="main-container">
            <div id="sidebar-img">
                <img src={logo} alt="logo" />
                </div>
                <ScrollableComponent id="scrollable-sidebar">
                <div id="feature-list">
                    <div class="container">
                            <div class="features">
                            <div class="feature-item">
                                <h2>Getting Started</h2>
                                    <h3>A Step-By-Step Guide</h3>
                                <p><em>Picture your entire network organized, accessible, and interactive. That's what CORE Contacts makes possible. In this guide, we'll walk hand-in-hand through Creating, Viewing, Editing, and Deleting contacts. Let's dive in!</em></p>
                            </div>
                                    <div class="feature-item">
                                    <h3>➕ Create Contact</h3>
                                    <ol>
                                        <li>Select the 'New' button, located at the base of the right sidebar.</li>
                                        <li>Complete the form by filling in your contact's details.</li>
                                        <li>Select 'Save' to add the contact or 'Cancel' to go back to the previous view.</li>
                                        </ol>
                            </div>
                                <div class="feature-item">
                                    <h3>👓 View Contact</h3>
                                    <ol>
                                        <li>Click on a contact from the right sidebar to view contact details.</li>
                                        <li>You may filter the contact list by typing the contact's name into the search bar.</li>
                                        <li>Once a contact has been selected, their details become available in the middle section of the application.</li>
                                    </ol>
                            </div>
                                <div class="feature-item">
                                    <h3>✏️ Edit Contact</h3>
                                    <ol>
                                        <li>While viewing a contact's details, select 'Edit' to make changes.</li>
                                        <li>After making updates, select 'Save' to keep the changes or 'Cancel' to dismiss the changes.</li>
                                    </ol>
                            </div>
                                <div class="feature-item">
                                    <h3>❌ Delete Contact</h3>
                                    <ol>
                                        <li>Also while viewing a contact's details, you may select 'Delete' to remove the contact.</li>
                                        <li>Select 'OK' to verify removal, or 'Cancel' to retain the contact.</li>
                                    </ol>
                                </div>
                                <div class="feature-item">
                                <p><em><strong>Congratulations!</strong> You've mastered contact management with CORE Contacts. Now, <strong>click</strong> 'New' to build more connections, and open the doors to limitless opportunities with CORE Contacts.</em></p>
                                </div>
                            </div>
                     </div>
                    </div>
                </ScrollableComponent>
                {/*<div>*/}
                {/*    <Form id="search-form" role="search">*/}
                {/*        <input*/}
                {/*            id="q"*/}
                {/*            className={searching ? "loading" : ""}*/}
                {/*            aria-label="Search contacts"*/}
                {/*            placeholder="Search"*/}
                {/*            type="search"*/}
                {/*            name="q"*/}
                {/*            defaultValue={q}*/}
                {/*            onChange={(event) => {*/}
                {/*                const isFirstSearch = q == null;*/}
                {/*                submit(event.currentTarget.form, {*/}
                {/*                    replace: !isFirstSearch,*/}
                {/*                });*/}
                {/*            }}*/}
                {/*        />*/}
                {/*        <div id="search-spinner" aria-hidden hidden={!searching} />*/}
                {/*        <div className="sr-only" aria-live="polite"></div>*/}
                {/*    </Form>*/}
                {/*    <Form method="post">*/}
                {/*        <button type="submit">New</button>*/}
                {/*    </Form>*/}
                {/*</div>*/}
                {/*    <nav>*/}
                {/*        {contacts.length ? (*/}
                {/*            <ul>*/}
                {/*                {contacts.map((contact) => (*/}
                {/*                    <li key={contact.id}>*/}
                {/*                        <NavLink to={`contacts/${contact.id}`}*/}
                {/*                            className={({ isActive, isPending }) =>*/}
                {/*                                isActive*/}
                {/*                                    ? "active"*/}
                {/*                                    : isPending*/}
                {/*                                        ? "pending"*/}
                {/*                                        : ""*/}
                {/*                            }*/}
                {/*                        >*/}
                {/*                            {contact.first || contact.last ? (*/}
                {/*                                <>*/}
                {/*                                    {contact.first} {contact.last}*/}
                {/*                                </>*/}
                {/*                            ) : (*/}
                {/*                                <i>No Name</i>*/}
                {/*                            )}{" "}*/}
                {/*                            {contact.favorite && <span>★</span>}*/}
                {/*                        </NavLink>*/}
                {/*                    </li>*/}
                {/*                ))}*/}
                {/*            </ul>*/}
                {/*        ) : (*/}
                {/*            <p>*/}
                {/*                <i>No contacts</i>*/}
                {/*            </p>*/}
                {/*        )}*/}
                {/*    </nav>*/}
                </div>

            <ScrollableComponent id="scrollable">
                <div id="detail" className={navigation.state === "loading" ? "loading" : ""}>
                    <Outlet />
                </div>
            </ScrollableComponent>
            <div id="right-sidebar">
            <div id="sidebar-img">
                <img src={YourCore} alt="YourCORE" />
                </div>
                <nav id="nav">
                    {contacts.length ? (
                        <ul>
                            {contacts.map((contact) => (
                                <li id="contact-card" key={contact.id}>
                                    <NavLink to={`contacts/${contact.id}`}
                                        className={({ isActive, isPending }) =>
                                            isActive
                                                ? "active"
                                                : isPending
                                                    ? "pending"
                                                    : ""
                                        }
                                    >
                                        {contact.firstName || contact.lastName ? (
                                            <div id="right-contact-card">
                                                <>
                                                    <div id="right-contact"><img key={contact.imageUrl} src={contact.imageUrl || null} /></div>
                                                </>
                                                <>
                                                    <div id="contact-card-text">
                                                        <article>{contact.firstName} {contact.lastName}</article>
                                                        <article>{contact.twitterUsername && (<a target="_blank" href={`https://twitter.com/${contact.twitterUsername}`}>{contact.twitterUsername}</a>)}</article>
                                                    </div>
                                                </>
                                            </div>
                                        ) : (
                                            <i>No Name</i>
                                        )}{" "}
                                        {contact.favorite && <span>★</span>}
                                    </NavLink>
                                </li>
                            ))}
                        </ul>
                    ) : (
                        <p>
                            <i>No contacts</i>
                        </p>
                    )}
                    </nav>
                <div>
                    <Form id="search-form" role="search">
                        <input
                            id="q"
                            className={searching ? "loading" : ""}
                            aria-label="Search contacts"
                            placeholder="Search"
                            type="search"
                            name="q"
                            defaultValue={q}
                            onChange={(event) => {
                                const isFirstSearch = q == null;
                                submit(event.currentTarget.form, {
                                    replace: !isFirstSearch,
                                });
                            }}
                        />
                        <div id="search-spinner" aria-hidden hidden={!searching} />
                        <div className="sr-only" aria-live="polite"></div>
                    </Form>
                    <Form method="post">
                        <NavLink to={`contacts/create`}
                            className={({ isActive, isPending }) =>
                                isActive
                                    ? "active"
                                    : isPending
                                        ? "pending"
                                        : ""
                            }
                        >
                            <button type="submit">New</button>
                        </NavLink>
                    </Form>
                </div>
            </div>
        </>
    );
}