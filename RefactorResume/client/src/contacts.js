const baseUrl = 'https://localhost:5001/api/contacts';

export async function getContacts(query) {
    const url = query ? `${baseUrl}?query=${encodeURIComponent(query)}` : baseUrl;
    const response = await fetch(url);
    return response.json();
}

export async function getContact(id) {
    const response = await fetch(`${baseUrl}/${id}`);
    return response.json();
}

export async function createContact(contact) {
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(contact),
    });
    return response.json();
}

export async function updateContact(id, updates) {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updates),
    });

    if (!response.ok) {
        throw new Error(`Failed to update contact: ${response.statusText}`);
    }
}

export async function deleteContact(id) {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE',
    });

    if (!response.ok) {
        throw new Error(`Failed to delete contact: ${response.statusText}`);
    }
}
