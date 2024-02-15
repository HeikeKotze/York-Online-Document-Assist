function Print() {
    $(".hideWhenPrint").hide();
    window.print();
    $(".hideWhenPrint").show();
}

function ViewFile() {
    var newTab = window.open(url, "_blank");
    if (newTab) {
        newTab.focus();
    }
}

// Use it for .NET 6+
function BlazorDownloadFile(filename, contentType, content) {
    // Create the URL
    const file = new File([content], filename, { type: contentType });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object URL, let's release the memory
    // On older versions of Safari, it seems you need to comment this line...
    URL.revokeObjectURL(exportUrl);
}

function downloadFile(fileName, fileUrl) {
    var link = document.getElementById("downloadLink");
    link.href = fileUrl;
    link.download = fileName;
    link.click();
}

function downloadNewFile(fileUrl, fileName) {
    fetch(fileUrl)
        .then(response => response.blob())
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = fileName;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);
        });
}

function BlazorDownloadFile(filename, contentType, data) {

    // Create the URL
    const file = new File([data], filename, { type: contentType });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the url, let's release the memory
    // On Safari it seems you need to comment this line... (please let me know if you know why)
    URL.revokeObjectURL(exportUrl);
    a.remove();
}

window.saveAsFile = function (fileName, fileBytes) {
    // Convert the byte array to a Blob
    const blob = new Blob([new Uint8Array(fileBytes)], { type: 'application/octet-stream' });

    // Create a temporary anchor element
    const a = document.createElement('a');
    a.style.display = 'none';
    document.body.appendChild(a);

    // Create a download URL for the Blob
    const url = window.URL.createObjectURL(blob);
    a.href = url;
    a.download = fileName;

    // Simulate a click on the anchor to trigger the download
    a.click();

    // Clean up
    window.URL.revokeObjectURL(url);
    document.body.removeChild(a);
}

function scrollToTopOrBottom(scrollToTop) {
    if (scrollToTop) {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    } else {
        window.scrollTo({ top: document.body.scrollHeight, behavior: 'smooth' });
    }
}



