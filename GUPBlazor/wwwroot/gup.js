// Dropdown field interactivity (no interactive render mode required)
window.__gupDropdown = {
    toggle(id) {
        const el = document.getElementById(id);
        if (!el) return;
        const isOpen = el.classList.toggle('gup-dropdown-field--open');
        const input = el.querySelector('.input');
        if (input) input.setAttribute('aria-expanded', isOpen);
        if (isOpen) {
            const search = el.querySelector('.search');
            if (search) { search.value = ''; this._showAll(el); search.focus(); }
            // Sync apply button state when reopening
            if (this._isMultiple(el)) this._updateApplyButton(el);
        }
    },
    close(el) {
        el.classList.remove('gup-dropdown-field--open');
        const input = el.querySelector('.input');
        if (input) input.setAttribute('aria-expanded', 'false');
    },
    _isMultiple(field) {
        const menu = field.querySelector('.gup-dropdown-menu');
        return menu && menu.dataset.multiple === 'true';
    },
    _getSelectedCount(field) {
        return field.querySelectorAll('.gup-dropdown-menu-item--selected').length;
    },
    selectItem(btn) {
        const item = btn.closest('.gup-dropdown-menu-item');
        const field = btn.closest('.gup-dropdown-field');
        if (!item || !field) return;
        const isMultiple = this._isMultiple(field);

        if (isMultiple) {
            // Toggle selection
            const isSelected = item.classList.toggle('gup-dropdown-menu-item--selected');
            const optionEl = item.querySelector('[role="option"]');
            if (optionEl) optionEl.setAttribute('aria-selected', isSelected.toString());
            const cb = item.querySelector('.gup-checkbox__input');
            if (cb) cb.checked = isSelected;
            // Update apply button with count
            this._updateApplyButton(field);
        } else {
            // Single select: deselect all, select one, close
            field.querySelectorAll('.gup-dropdown-menu-item').forEach(mi => {
                mi.classList.remove('gup-dropdown-menu-item--selected');
                const b = mi.querySelector('[role="option"]');
                if (b) b.setAttribute('aria-selected', 'false');
                const ci = mi.querySelector('.check-icon-wrapper');
                if (ci) ci.style.display = 'none';
            });
            item.classList.add('gup-dropdown-menu-item--selected');
            const optionEl = item.querySelector('[role="option"]');
            if (optionEl) optionEl.setAttribute('aria-selected', 'true');
            const ci = item.querySelector('.check-icon-wrapper');
            if (ci) ci.style.display = '';
            const input = field.querySelector('.input');
            if (input) input.value = item.dataset.label;
            this.close(field);
        }
    },
    applySelection(applyBtn) {
        const field = applyBtn.closest('.gup-dropdown-field');
        if (!field) return;
        const count = this._getSelectedCount(field);
        const input = field.querySelector('.input');
        const valuesLabel = field.dataset.multipleValuesLabel || ' selected';
        if (input) {
            input.value = count > 0 ? count + valuesLabel : '';
        }
        this._updateClearButton(field, count > 0);
        this.close(field);
    },
    clearSelection(fieldId) {
        const field = document.getElementById(fieldId);
        if (!field) return;
        field.querySelectorAll('.gup-dropdown-menu-item').forEach(mi => {
            mi.classList.remove('gup-dropdown-menu-item--selected');
            const optionEl = mi.querySelector('[role="option"]');
            if (optionEl) optionEl.setAttribute('aria-selected', 'false');
            const cb = mi.querySelector('.gup-checkbox__input');
            if (cb) cb.checked = false;
        });
        const input = field.querySelector('.input');
        if (input) input.value = '';
        this._updateClearButton(field, false);
        this._updateApplyButton(field);
    },
    _updateClearButton(field, show) {
        const clearBtn = field.querySelector('.gup-dropdown-clear-btn');
        if (clearBtn) clearBtn.style.display = show ? '' : 'none';
    },
    _updateApplyButton(field) {
        const applyBtn = field.querySelector('.gup-dropdown-apply-btn');
        if (!applyBtn) return;
        const count = this._getSelectedCount(field);
        if (count > 0) {
            const itemsLabel = applyBtn.dataset.itemsLabel || 'Apply';
            applyBtn.textContent = itemsLabel + ' (' + count + ')';
            applyBtn.classList.add('gup-dropdown-apply-btn--primary');
        } else {
            const noSelLabel = applyBtn.dataset.noSelLabel || 'Done';
            applyBtn.textContent = noSelLabel;
            applyBtn.classList.remove('gup-dropdown-apply-btn--primary');
        }
    },
    filterItems(searchInput) {
        const menu = searchInput.closest('.gup-dropdown-menu');
        if (!menu) return;
        const term = searchInput.value.toLowerCase();
        const items = menu.querySelectorAll('.gup-dropdown-menu-item');
        let visible = 0;
        items.forEach(item => {
            const label = (item.dataset.label || '').toLowerCase();
            const match = !term || label.includes(term);
            item.style.display = match ? '' : 'none';
            if (match) visible++;
        });
        const noResults = menu.querySelector('.no-results');
        if (noResults) noResults.style.display = visible === 0 ? '' : 'none';
    },
    _showAll(el) {
        el.querySelectorAll('.gup-dropdown-menu-item').forEach(i => i.style.display = '');
        const nr = el.querySelector('.no-results');
        if (nr) nr.style.display = 'none';
    }
};
// Close dropdown when clicking outside
document.addEventListener('click', function (e) {
    document.querySelectorAll('.gup-dropdown-field--open').forEach(function (dd) {
        if (!dd.contains(e.target)) {
            // For multiple mode, apply selection before closing
            if (window.__gupDropdown._isMultiple(dd)) {
                var count = window.__gupDropdown._getSelectedCount(dd);
                var input = dd.querySelector('.input');
                var valuesLabel = dd.dataset.multipleValuesLabel || ' selected';
                if (input) input.value = count > 0 ? count + valuesLabel : '';
                window.__gupDropdown._updateClearButton(dd, count > 0);
            }
            window.__gupDropdown.close(dd);
        }
    });
});

// File upload interactivity (no interactive render mode required)
window.__gupFileUpload = {
    // Internal storage: id → array of { file, thumbnail }
    _state: {},
    // Registered .NET callbacks: id → DotNetObjectReference
    _callbacks: {},

    _getField(inputEl) {
        return inputEl.closest('.gup-file-upload');
    },
    registerCallback(fieldId, dotnetRef) {
        this._callbacks[fieldId] = dotnetRef;
    },
    unregisterCallback(fieldId) {
        delete this._callbacks[fieldId];
    },
    _notifyChange(field) {
        const id = field.id;
        const cb = this._callbacks[id];
        if (!cb) return;
        const files = (this._state[id] || []).map(item => ({
            name: item.file.name,
            size: item.file.size,
            type: item.file.type || '',
            lastModified: item.file.lastModified || 0,
        }));
        cb.invokeMethodAsync('NotifyFilesChanged', files);
    },
    _formatSize(bytes) {
        const MB = 1024 * 1024;
        const KB = 1024;
        if (bytes >= MB) return (bytes / MB).toFixed(2) + ' MB';
        return (bytes / KB).toFixed(2) + ' KB';
    },
    _escape(s) {
        return String(s == null ? '' : s)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;');
    },
    _setSizeError(field, message) {
        const sizeEl = field.querySelector('.size-error-message');
        if (!sizeEl) return;
        if (message) {
            sizeEl.textContent = message;
            sizeEl.style.display = '';
        } else {
            sizeEl.textContent = '';
            sizeEl.style.display = 'none';
        }
    },
    _render(field) {
        const id = field.id;
        const files = this._state[id] || [];
        const container = field.querySelector('.uploaded-files');
        if (!container) return;

        if (files.length === 0) {
            container.innerHTML = '';
            container.style.display = 'none';
        } else {
            const allowThumbnails = field.dataset.allowThumbnails === 'true';
            const deleteLabel = field.dataset.itemDeleteLabel || 'Remove the file';
            container.innerHTML = files.map((item, idx) => {
                const f = item.file;
                const date = new Date(f.lastModified).toLocaleDateString();
                const subtitle = date + ', ' + this._formatSize(f.size);
                const thumb = allowThumbnails && item.thumbnail
                    ? `<img src="${this._escape(item.thumbnail.src)}" alt="${this._escape(item.thumbnail.alt)}" class="thumbnail">`
                    : '';
                return `
                    <div class="gup-file-item">
                        <div class="inner">
                            ${thumb}
                            <div class="meta">
                                <h2 class="title">${this._escape(f.name)}</h2>
                                <small class="subtitle">${this._escape(subtitle)}</small>
                            </div>
                            <div class="gup-button gup-button--text">
                                <button type="button" class="button" aria-label="${this._escape(deleteLabel)}" title="${this._escape(deleteLabel)}" onclick="window.__gupFileUpload.deleteFile('${id}', ${idx})">
                                    <span class="gup-icon" style="width:24px; height:24px;" aria-hidden="true">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24">
                                            <path d="M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM8.46 11.88l1.41-1.41L12 12.59l2.12-2.12 1.41 1.41L13.41 14l2.12 2.12-1.41 1.41L12 15.41l-2.12 2.12-1.41-1.41L10.59 14l-2.13-2.12zM15.5 4l-1-1h-5l-1 1H5v2h14V4z"/>
                                        </svg>
                                    </span>
                                </button>
                            </div>
                        </div>
                    </div>`;
            }).join('');
            container.style.display = '';
        }

        // Hide the input-wrapper when single-file mode already has a file
        const multiple = field.dataset.multiple === 'true';
        const inputWrapper = field.querySelector('.input-wrapper');
        const actions = field.querySelector('.actions');
        if (inputWrapper && actions) {
            const hide = !multiple && files.length > 0;
            inputWrapper.style.display = hide ? 'none' : '';
            // If extra-action is the only thing left, keep actions visible; else hide entire actions row
            const extra = field.querySelector('.extra-action-slot');
            if (!extra && hide) actions.style.display = 'none';
            else actions.style.display = '';
        }

        // Sync native input's files data and required validity
        this._syncFormValue(field);
    },
    _syncFormValue(field) {
        const id = field.id;
        const input = field.querySelector('.native-input');
        if (!input) return;
        const files = this._state[id] || [];
        try {
            const dt = new DataTransfer();
            files.forEach(item => dt.items.add(item.file));
            input.files = dt.files;
        } catch (e) {
            // DataTransfer may not be writable in some older browsers; ignore
        }
    },
    handleChange(input) {
        const field = this._getField(input);
        if (!field) return;
        const id = field.id;
        const maxFileSize = parseFloat(field.dataset.maxFileSize || '0');
        const allowThumbnails = field.dataset.allowThumbnails === 'true';
        const sizeMsg = field.dataset.sizeValidationMessage || 'Maximum file size exceeded!';
        const multiple = field.dataset.multiple === 'true';

        const files = Array.from(input.files || []);
        if (files.length === 0) return;

        // Validate sizes first
        if (maxFileSize > 0) {
            const tooBig = files.some(f => f.size > maxFileSize * 1024 * 1024);
            if (tooBig) {
                this._setSizeError(field, sizeMsg);
                input.value = '';
                return;
            }
        }
        this._setSizeError(field, null);

        const current = multiple ? (this._state[id] || []).slice() : [];
        let pending = files.length;
        const additions = [];

        const finalize = () => {
            this._state[id] = current.concat(additions);
            this._render(field);
            input.value = '';
            this._notifyChange(field);
        };

        files.forEach(file => {
            const type = (file.type || '').split('/')[0];
            if (allowThumbnails && type === 'image') {
                const reader = new FileReader();
                reader.onload = (e) => {
                    additions.push({ file, thumbnail: { src: e.target.result, alt: file.name } });
                    if (--pending === 0) finalize();
                };
                reader.onerror = () => {
                    additions.push({ file, thumbnail: null });
                    if (--pending === 0) finalize();
                };
                reader.readAsDataURL(file);
            } else {
                additions.push({ file, thumbnail: null });
                if (--pending === 0) finalize();
            }
        });
    },
    deleteFile(fieldId, index) {
        const field = document.getElementById(fieldId);
        if (!field) return;
        const list = (this._state[fieldId] || []).slice();
        list.splice(index, 1);
        this._state[fieldId] = list;
        this._render(field);
        this._notifyChange(field);
    },
    // Seed a component with pre-populated files (used by demos)
    seed(fieldId, items) {
        const field = document.getElementById(fieldId);
        if (!field) return;
        this._state[fieldId] = items.map(it => ({
            file: it.file instanceof File
                ? it.file
                : new File([it.content || ''], it.fileName, { type: it.type || '', lastModified: it.lastModified || Date.now() }),
            thumbnail: it.thumbnail || null,
        }));
        this._render(field);
    },
};

// Demo helper: simulate loading state for a dropdown
window.__gupDropdownLoadingDemo = function (id) {
    var dd = document.getElementById(id);
    if (!dd) return;
    var endSlot = dd.querySelector('.field-end-slot');
    var input = dd.querySelector('.input');
    if (!endSlot || !input) return;

    // Save original state
    var originalHTML = endSlot.innerHTML;
    var originalPlaceholder = input.placeholder;

    // Show spinner
    endSlot.innerHTML = '<div class="gup-dropdown-spinner-wrapper">' +
        '<svg class="gup-dropdown-spinner" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 40 40" fill="none" width="20" height="20" role="status" aria-label="Loading...">' +
        '<mask id="mask-spinner-demo" style="mask-type:alpha" maskUnits="userSpaceOnUse" x="0" y="0">' +
        '<path d="M40 20C40 31.0457 31.0457 40 20 40C8.9543 40 -5.4282e-06 31.0457 -3.49691e-06 20C-1.56562e-06 8.9543 8.9543 1.56562e-06 20 3.49691e-06C31.0457 5.4282e-06 40 8.95431 40 20ZM6 20C6 27.732 12.268 34 20 34C27.732 34 34 27.732 34 20C34 12.268 27.732 6 20 6C12.268 6 6 12.268 6 20Z" /></mask>' +
        '<g mask="url(#mask-spinner-demo)">' +
        '<circle class="gup-dropdown-spinner-circle" cx="20" cy="20" r="20" />' +
        '<path class="gup-dropdown-spinner-indicator" d="M40 20C40 25.3043 37.8929 30.3914 34.1421 34.1421C30.3914 37.8929 25.3043 40 20 40L20 20L40 20Z"/>' +
        '</g></svg></div>';
    input.placeholder = 'Loading...';

    // Prevent toggling while loading
    var fieldWrapper = dd.querySelector('.field-wrapper');
    var originalOnclick = fieldWrapper.getAttribute('onclick');
    fieldWrapper.removeAttribute('onclick');

    // Revert after 3 seconds
    setTimeout(function () {
        endSlot.innerHTML = originalHTML;
        input.placeholder = originalPlaceholder;
        if (originalOnclick) fieldWrapper.setAttribute('onclick', originalOnclick);
    }, 3000);
};
