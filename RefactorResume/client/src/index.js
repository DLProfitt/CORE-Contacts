////Imports
import * as React from "react";
import * as ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
//Styles
import "./index.css";
//UI, loaders, actions
import Root, { loader as rootLoader, action as rootAction } from "./routes/root.js";
import ErrorPage from "./error-page.js";
import Contact, { loader as contactLoader, action as contactAction } from "./routes/contact.js";
import EditContact, { action as editAction } from "./routes/edit.js";
import { action as destroyAction } from "./routes/destroy.js";
import ContactBlog from "./routes/contactBlog.js";

////Router Config
const router = createBrowserRouter([
    {
        path: "/",
        element: <Root />,
        errorElement: <ErrorPage />,
        loader: rootLoader,
        action: rootAction,
        children: [
            {
                errorElement: <ErrorPage />,
                children: [
                    { index: true, element: <ContactBlog /> },
                    {
                        path: "contacts/:contactId",
                        element: <Contact />,
                        loader: contactLoader,
                        action: contactAction,
                    },
                    {
                        path: "contacts/:contactId/edit",
                        element: <EditContact />,
                        loader: contactLoader,
                        action: editAction,
                    },
                    {
                        path: "contacts/:contactId/destroy",
                        action: destroyAction,
                    },
                ]
            },
        ],
    },
]);

////Establishing Root
ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);