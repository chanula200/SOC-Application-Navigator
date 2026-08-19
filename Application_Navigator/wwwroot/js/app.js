document.addEventListener('DOMContentLoaded', () => {
    const statusMessage = document.getElementById('status-message');

    const showStatus = (message, isError = false) => {
        statusMessage.textContent = message;
        statusMessage.classList.toggle('error', isError);
        statusMessage.classList.add('visible');
        clearTimeout(showStatus.timer);
        showStatus.timer = setTimeout(() => statusMessage.classList.remove('visible'), 3000);
    };

    const openSystem = async (card) => {
        const button = card.querySelector('.nav-button');
        if (button && button.disabled) return;

        const originalLabel = button ? button.innerHTML : '';
        if (button) {
            button.disabled = true;
            button.textContent = 'Opening...';
        }

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
            if (button) {
                button.disabled = false;
                button.innerHTML = originalLabel;
            }
        }
    };

    document.querySelectorAll('.service-card').forEach((card) => {
        card.addEventListener('click', () => openSystem(card));
        card.addEventListener('keydown', (e) => {
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                openSystem(card);
            }
        });
    });
});
