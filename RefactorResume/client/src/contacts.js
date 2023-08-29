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
    try {
        const response = await fetch(`${baseUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updates),
        });

        console.log("Sending updates:", JSON.stringify(updates, null, 2));

        console.log('HTTP status:', response.status);

        if (response.status === 204) {
            console.log('Update successful but no content returned');
            return null;
        }

        if (!response.ok) {
            throw new Error(`Failed to update contact: ${response.statusText}`);
        }

        const jsonResponse = await response.json();
        console.log('Update successful', jsonResponse);
        return jsonResponse;
    } catch (error) {
        console.error('An error occurred:', error);
        throw error;
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
