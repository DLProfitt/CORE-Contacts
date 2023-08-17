////Imports
import * as React from "react";
import * as ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
//Styles
import "./index.css";
//UI, loaders, actions
import Root, { loader as rootLoader, action as rootAction } from "./routes/root.js";
import ErrorPage from "./error-page.js";
import Contact, { loader as contactLoader } from "./routes/contact.js";
import EditContact, { action as editAction } from "./routes/edit.js";
import { action as destroyAction } from "./routes/destroy.js";

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
                path: "contacts/:contactId",
                element: <Contact />,
                loader: contactLoader,
                errorElement: <div> Oopsies! There was an error.</div>,
            },
            {
                path: "contacts/:contactId/edit",
                element: <EditContact />,
                loader: contactLoader,
                action: editAction,
                errorElement: <div> Oopsies! There was an error with editing.</div>,
            },
            {
                path: "contacts/:contactId/destroy",
                action: destroyAction,
                errorElement: <div> Oopsies! There was an error with deletion.</div>,
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