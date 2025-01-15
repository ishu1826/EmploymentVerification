// EmploymentVerificationForm.js
// Plain JavaScript implementation

document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('verification-form');
    const resultContainer = document.getElementById('result');

    form.addEventListener('submit', async function (e) {
        debugger;
        e.preventDefault();

        const employeeId = document.getElementById('employeeId').value;
        const companyName = document.getElementById('companyName').value;
        const verificationCode = document.getElementById('verificationCode').value;

        const payload = {
            employeeId: parseInt(employeeId),
            companyName,
            verificationCode,
        };

        try {
            const response = await fetch('https://localhost:7283/api/verify-employment', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(payload),
            });

            const data = await response.json();

            if (response.ok) {
                resultContainer.textContent = `Result: ${data.status}`;
                resultContainer.style.color = 'green';
            } else {
                resultContainer.textContent = `Error: ${data.status }`;
                resultContainer.style.color = 'red';
            }
        } catch (err) {
            console.log(err);
            resultContainer.textContent = 'Failed to connect to the server';
            resultContainer.style.color = 'red';
        }
    });
});
