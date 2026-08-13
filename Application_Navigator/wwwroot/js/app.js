document.addEventListener('DOMContentLoaded', () => {
    const statusMessage = document.getElementById('status-message');
    const overlay = document.getElementById('service-id-overlay');
    const sidInput = document.getElementById('sid-input');
    const sidError = document.getElementById('sid-error');
    const sidConfirm = document.getElementById('sid-confirm');
    const sidCancel = document.getElementById('sid-cancel');

    const showStatus = (message, isError = false) => {
        statusMessage.textContent = message;
        statusMessage.classList.toggle('error', isError);
        statusMessage.classList.add('visible');
        clearTimeout(showStatus.timer);
        showStatus.timer = setTimeout(() => statusMessage.classList.remove('visible'), 3000);
    };

    let pendingCard = null;

    const openModal = (card) => {
        pendingCard = card;
        sidInput.value = '';
        sidError.textContent = '';
        sidInput.classList.remove('invalid');
        overlay.style.display = 'flex';
        setTimeout(() => sidInput.focus(), 50);
    };

    const closeModal = () => {
        overlay.style.display = 'none';
        pendingCard = null;
    };

    const validate = () => {
        const val = sidInput.value.trim();
        if (!/^\d{6}$/.test(val)) {
            sidError.textContent = 'Service ID must be exactly 6 digits (numbers only).';
            sidInput.classList.add('invalid');
            return false;
        }
        sidError.textContent = '';
        sidInput.classList.remove('invalid');
        return true;
    };

    sidInput.addEventListener('input', () => {
        sidInput.value = sidInput.value.replace(/\D/g, '').slice(0, 6);
        if (sidInput.classList.contains('invalid')) validate();
    });

    sidConfirm.addEventListener('click', async () => {
        if (!validate() || !pendingCard) return;
        const card = pendingCard;
        const button = card.querySelector('.nav-button');
        closeModal();
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
    });

    sidCancel.addEventListener('click', closeModal);
    overlay.addEventListener('click', (e) => { if (e.target === overlay) closeModal(); });
    document.addEventListener('keydown', (e) => { if (e.key === 'Escape') closeModal(); });

    sidInput.addEventListener('keydown', (e) => {
        if (e.key === 'Enter') sidConfirm.click();
    });

    document.querySelectorAll('.service-card').forEach((card) => {
        const button = card.querySelector('.nav-button');
        button.addEventListener('click', () => openModal(card));
        card.addEventListener('keydown', (e) => {
            if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); openModal(card); }
        });
    });
});
