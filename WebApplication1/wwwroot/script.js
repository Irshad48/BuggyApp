document.addEventListener('DOMContentLoaded', function () {
    fetch('https://localhost:5001/api/invoice')
        .then(resp => resp.json())
        .then(data => {
            let html = '';
            data.forEach(invoice => {
                html += `<li>${invoice.invoiceID} - ${invoice.customerName}</li>`;
                html += '<ul>';
                invoice.items.forEach(item => {
                    html += `<li>${item.name} - $${item.price}</li>`;
                });
                html += '</ul>';
            });
            document.getElementById('invoice-container').innerHTML = html;
        })
        .catch(err => console.error("Failed to load invoice:", err));
});
