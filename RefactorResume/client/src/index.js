////Imports___________________________________
import * as React from "react";
import * as ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
//Styles______________________________________
import "./index.css";
//Contexts____________________________________
import { AuthProvider } from "./contexts/AuthContext.js";
//UI, loaders, actions________________________
import Root, { loader as rootLoader, action as rootAction } from "./routes/root.js";
import ErrorPage from "./error-page.js";
import Contact, { loader as contactLoader } from "./routes/contact.js";
import EditContact, { action as editAction } from "./routes/edit.js";
import { action as destroyAction } from "./routes/destroy.js";
import ContactBlog from "./routes/contactBlog.js";
import CreateContact, { loader as createLoader, action as createAction } from "./routes/createContact.js";

////Router Config_____________________________
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
                        path: "contacts/create",
                        element: <CreateContact />,
                        loader: createLoader,
                        action: createAction,
                    },
                    {
                        path: "contacts/:contactId",
                        element: <Contact />,
                        loader: contactLoader,
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

////Establishing Root_________________________
ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <AuthProvider>
            <RouterProvider router={router} />
        </AuthProvider>
    </React.StrictMode>
);