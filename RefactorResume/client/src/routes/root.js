/* eslint-disable no-restricted-globals */
/* eslint-disable react/jsx-no-target-blank */
////Imports
import { useEffect } from "react";
import { Outlet, NavLink, useLoaderData, Form, useNavigation, useSubmit, } from "react-router-dom";
import { getContacts, createContact, } from "../contacts";
import { ScrollableComponent } from "../functionality/addFunction.js";

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
        new URLSearchParams(navigation.location.search).has(
            "q"
        );

    useEffect(() => {
        document.getElementById("q").value = q;
    }, [q]);

    return (
        <>
            <div id="sidebar">
                <h1>Refactor(Resume)</h1>
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
                                submit(event.currentTarget.form);
                            }}
                        />
                        <div id="search-spinner" aria-hidden hidden={!searching} />
                        <div className="sr-only" aria-live="polite"></div>
                    </Form>
                    <Form method="post">
                        <button type="submit">New</button>
                    </Form>
                </div>
                <nav>
                    {contacts.length ? (
                        <ul>
                            {contacts.map((contact) => (
                                <li key={contact.id}>
                                    <NavLink to={`contacts/${contact.id}`}
                                        className={({ isActive, isPending }) =>
                                            isActive
                                                ? "active"
                                                : isPending
                                                    ? "pending"
                                                    : ""
                                        }
                                    >
                                        {contact.first || contact.last ? (
                                            <>
                                                {contact.first} {contact.last}
                                            </>
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
            </div>
            <ScrollableComponent>
            <div id="detail" className={ navigation.state === "loading" ? "loading" : "" }>
                <Outlet />
                </div>
            </ScrollableComponent>
            <div id="right-sidebar">
                <h1>Contacts</h1>
                <nav id="right-nav">
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
                                        {contact.first || contact.last ? (
                                            <div id="right-contact-card">
                                            <>
                                                <div id="right-contact"><img key={contact.avatar} src={contact.avatar || null} /></div>
                                            </>
                                            <>                                                
                                                    <div id="contact-card-text">
                                                        <article>{contact.first} {contact.last}</article>
                                                        <article>{contact.twitter && (<a target="_blank" href={`https://twitter.com/${contact.twitter}`}>{contact.twitter}</a>)}</article>
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
                                submit(event.currentTarget.form);
                            }}
                      />
                        <div id="search-spinner" aria-hidden hidden={!searching} />
                      <div className="sr-only" aria-live="polite"></div>
                    </Form>
                    <Form method="post">
                        <button type="submit">New</button>
                    </Form>
                </div>
            </div>
        </>
    );
}