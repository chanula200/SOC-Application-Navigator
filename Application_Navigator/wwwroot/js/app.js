document.addEventListener('DOMContentLoaded', () => {
    const statusMessage = document.getElementById('status-message');
    const showStatus = (message, isError = false) => {
        statusMessage.textContent = message;
        statusMessage.classList.toggle('error', isError);
        statusMessage.classList.add('visible');
        clearTimeout(showStatus.timer);
        showStatus.timer = setTimeout(() => statusMessage.classList.remove('visible'), 3000);
    };

    document.querySelectorAll('.service-card').forEach((card) => {
        const button = card.querySelector('.nav-button');
        const navigate = async () => {
            if (button.disabled) return;
            const originalLabel = button.innerHTML;
            button.disabled = true;
            button.textContent = 'Opening...';
            try {
                const response = await fetch('/Home/Navigate', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ systemName: card.dataset.name, url: card.dataset.url })
                });
                if (!response.ok) throw new Error('Navigation request failed');
                const data = await response.json();
                window.open(card.dataset.url, '_blank', 'noopener');
                showStatus(data.message || `Opening ${card.dataset.name}`);
            } catch {
                showStatus('Unable to open this system. Please try again.', true);
            } finally {
                button.disabled = false;
                button.innerHTML = originalLabel;
            }
        };
        button.addEventListener('click', navigate);
        card.addEventListener('keydown', (event) => {
            if (event.key === 'Enter' || event.key === ' ') { event.preventDefault(); navigate(); }
        });
    });
});
