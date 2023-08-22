const baseUrl = 'https://localhost:5001/api/users';

export async function getAllUsers() {
    const response = await fetch(baseUrl);
    return response.json();
}

export async function getUser(id) {
    const response = await fetch(`${baseUrl}/${id}`);
    return response.json();
}

export async function login(email, password) {
    const response = await fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
        throw new Error('Login failed');
    }

    return response.json();
}

export async function addUser(user) {
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    return response.json();
}

export async function updateUser(id, user) {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });

    if (!response.ok) {
        throw new Error(`Failed to update user: ${response.statusText}`);
    }
}

export async function deleteUser(id) {
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE',
    });

    if (!response.ok) {
        throw new Error(`Failed to delete user: ${response.statusText}`);
    }
}
