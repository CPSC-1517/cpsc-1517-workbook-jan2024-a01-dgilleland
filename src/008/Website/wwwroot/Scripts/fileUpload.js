let file;

function handleFileUpload() {
    file = document.getElementById('fileUpload').files[0];
}

async function saveFile() {
    const data = new FormData();
    data.append('file', file);

    const response = await fetch('/api/upload', {
        method: 'POST',
        body: data
    });

    if (!response.ok) {
        throw new Error(`Error: ${response.statusText}`);
    }
}
