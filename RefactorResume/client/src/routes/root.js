﻿/* eslint-disable no-restricted-globals */
/* eslint-disable react/jsx-no-target-blank */
////Imports
import { useEffect, } from "react";
import { Outlet, NavLink, useLoaderData, Form, useNavigation, useSubmit, } from "react-router-dom";
import { getContacts, createContact, } from "../contacts";
import { ScrollableComponent } from "../utils/addFunction.js";
import logo from "../assets/core-logo.png";
import YourCore from "../assets/your-core.png";

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
            <div id="sidebar">
                <img src={logo} alt="logo" />
                <h1></h1>
                <div id="feature-list">
                    <div className="feature-item">
                        <h3>Connect</h3>
                    </div>
                    <div className="feature-item">
                        <h3>Organize</h3>
                    </div>
                    <div className="feature-item">
                        <h3>Reference</h3>
                    </div>
                    <div className="feature-item">
                        <h3>Engage</h3>
                    </div>
                </div>
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
            <ScrollableComponent>
                <div id="detail" className={navigation.state === "loading" ? "loading" : ""}>
                    <Outlet />
                </div>
            </ScrollableComponent>
            <div id="right-sidebar">
                <div id="right-sidebar-card">
                    <img src={YourCore} alt="Your.CORE" />
                </div>
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