// GUPBlazor Demo - Storybook-style Component Direction & Arabic Localization Controller
(function () {
    // Comprehensive dictionary mapping Gov.om component English texts to Arabic
    var DICTIONARY = {
        // ── Common Actions & Buttons ──
        "Button Primary": "زر أساسي",
        "Button Secondary": "زر ثانوي",
        "Button Text": "زر نصي",
        "Button Danger": "زر إلغاء",
        "Icon start": "رمز في البداية",
        "Icon end": "رمز في النهاية",
        "Icon only": "رمز فقط",
        "Full width": "عرض كامل",
        "Small": "صغير",
        "Large": "كبير",
        "Default": "افتراضي",
        "Search...": "ابحث...",
        "Search for something...": "ابحث في الخدمات الحكومية...",
        "Submit Application": "تقديم الطلب",
        "Submit": "إرسال",
        "Save Draft": "حفظ كمسودة",
        "Save": "حفظ",
        "Cancel": "إلغاء",
        "Delete": "حذف",
        "Edit": "تعديل",
        "Update": "تحديث",
        "Continue": "متابعة",
        "Confirm": "تأكيد",
        "Next": "التالي",
        "Back": "السابق",
        "Previous": "السابق",
        "Close": "إغلاق",
        "Open": "فتح",
        "Download": "تنزيل",
        "Upload": "تحميل ملف",
        "Upload a file": "تحميل ملف",
        "Search": "بحث",
        "Search…": "ابحث…",
        "Search for something…": "ابحث في الخدمات الحكومية…",
        "Search services": "البحث في الخدمات",
        "Reset": "إعادة تعيين",
        "Clear": "مسح",
        "Discard": "تجاهل",
        "Save now": "حفظ الآن",
        "Bring it back": "استعادة التنبيه",
        "Primary": "أساسي",
        "Secondary": "ثانوي",
        "Text": "نصي",
        "Danger": "إلغاء المعاملة",
        "Disabled": "معطل",
        "Loading": "جارٍ التحميل...",
        "Link Primary": "رابط أساسي",
        "Link Secondary": "رابط ثانوي",
        "Link Text": "رابط نصي",
        "Click me": "اضغط هنا للتفاصيل",
        "Click me too": "خيارات إضافية للخدمة",
        "Slip merely pocket large no copy": "المستندات والمتطلبات الإلزامية",
        "Crop copy ate accept anything leather fifty": "الرسوم ومراحل إصدار الترخيص",
        "I am open by default": "شروط ومعايير الاستحقاق",
        "I am closed by default": "فترة مراجعة واعتماد الطلب",
        "I am an accordion item": "تتم معالجة الطلبات خلال يومين عمل من تاريخ السداد.",
        "I am alone": "عنصر توضيحي منفرد",
        "An accordion item can be used outside a GupAccordion wrapper.": "يمكن استخدام عنصر القائمة القابلة للطي بشكل منفصل.",
        "Some hidden content": "نسخة من السجل التجاري والبطاقة الشخصية سارية المفعول.",
        "Some other hidden content": "تتم معالجة الطلبات المقدمة إلكترونياً عبر البوابة الموحدة.",

        // ── Form Fields & Labels ──
        "Full name": "الاسم الكامل",
        "First name": "الاسم الأول",
        "Middle name": "اسم الأب",
        "Last name": "القبيلة / اسم العائلة",
        "National ID": "الرقم المدني",
        "Civil ID": "الرقم المدني",
        "Civil ID number": "الرقم المدني",
        "Enter the number as shown on your ID card.": "أدخل الرقم المدني كما هو مدون في البطاقة الشخصية.",
        "Required field": "حقل إلزامي",
        "Read-only field": "حقل للقراءة فقط",
        "Disabled field": "حقل معطل",
        "Label hidden": "تسمية مخفية",
        "Email": "البريد الإلكتروني",
        "Phone number": "رقم الهاتف",
        "Mobile number": "رقم الهاتف النقال",
        "Address": "العنوان الوطني",
        "Governorate": "المحافظة",
        "Wilayat": "الولاية",
        "Area": "المنطقة / الحي",
        "Way number": "رقم السكة",
        "House number": "رقم المبنى",
        "Additional directions": "إرشادات إضافية لتحديد الموقع",
        "Landmarks or directions that help a courier find the address.": "معالم أو إرشادات تسهل الوصول إلى العنوان بدقة.",
        "Select a governorate": "اختر المحافظة",
        "Select governorate": "اختر المحافظة",
        "Select wilayat": "اختر الولاية",
        "Select document type": "اختر نوع المستند",
        "Please Select": "يرجى الاختيار",
        "Document type": "نوع المستند",
        "Passport": "جواز السفر",
        "Driving License": "رخصة القيادة",
        "Muscat": "محافظة مسقط",
        "Dhofar": "محافظة ظفار",
        "Musandam": "محافظة مسندم",
        "Al Buraimi": "محافظة البريمي",
        "Ad Dakhiliyah": "محافظة الداخلية",
        "Al Batinah North": "محافظة شمال الباطنة",
        "Al Batinah South": "محافظة جنوب الباطنة",
        "Ash Sharqiyah North": "محافظة شمال الشرقية",
        "Ash Sharqiyah South": "محافظة جنوب الشرقية",
        "Ad Dhahirah": "محافظة الظاهرة",
        "Al Wusta": "محافظة الوسطى",
        "Muttrah": "ولاية مطرح",
        "Bawshar": "ولاية بوشر",
        "Seeb": "ولاية السيب",
        "Al Amarat": "ولاية العامرات",
        "Quriyat": "ولاية قريات",
        "Ahmed Al Habsi": "أحمد بن سعيد الحارثي",
        "e.g. Ahmed Al Habsi": "مثال: أحمد بن سعيد الحارثي",
        "Cannot edit": "لا يمكن التعديل",
        "Watch the validation message": "رسالة التحقق تظهر هنا",
        "Please enter a valid message of 10–100 characters.": "يرجى إدخال نص صحيح يتراوح بين ١٠ إلى ١٠٠ حرف.",
        "This message is shown only when invalid.": "تظهر هذه الرسالة فقط عند وجود خطأ في البيانات المدخلة.",

        // ── Breadcrumbs & Navigation ──
        "Home": "الصفحة الرئيسية",
        "Store": "دليل الخدمات",
        "Category": "خدمات الأفراد",
        "Phone": "الاتصالات",
        "Phone specs": "تفاصيل الخدمة",
        "Settling in Oman": "الإقامة في سلطنة عمان",
        "Representative of an Overseas Business visa": "تأشيرة ممثل لشركة أجنبية",
        "Mark Home as current": "تحديد الرئيسية كحالية",
        "Mark Store as current": "تحديد دليل الخدمات كحالي",
        "Mark Category as current": "تحديد التصنيف كحالي",

        // ── Tabs ──
        "First tab": "التبويب الأول",
        "Second tab": "التبويب الثاني",
        "Third tab": "التبويب الثالث",
        "Panel for first tab": "محتوى وبيانات التبويب الأول",
        "Panel for second tab": "محتوى وبيانات التبويب الثاني",
        "Panel for third tab": "محتوى وبيانات التبويب الثالث",
        "Overview": "نظرة عامة",
        "Details": "التفاصيل",
        "History": "السجل",
        "Service overview content.": "ملخص شامل حول الخدمة وشروط الاستحقاق.",
        "Detailed service description.": "الوصف التفصيلي لمراحل تنفيذ المعاملة.",
        "Service request history.": "سجل المعاملات والطلبات المقدمة سابقاً.",
        "Drafts": "المسودات",
        "Sent": "المرسلة",
        "You have 3 unread messages.": "لديك ٣ رسائل جديدة غير مقروءة.",
        "2 drafts saved.": "تم حفظ مسودتين بنجاح.",
        "No sent messages today.": "لا توجد رسائل مرسلة اليوم.",

        // ── Badges & Chips ──
        "Approved": "تم الاعتماد",
        "Pending": "قيد المعالجة",
        "Rejected": "مرفوض",
        "Featured": "مميز",
        "Verified": "موثق رسمي",
        "New": "جديد",
        "Label": "شارة",
        "Neutral": "تنويه",
        "Neutral (default)": "افتراضي",
        "Positive": "إيجابي",
        "Positive filled": "معتمد ومؤكد",
        "Negative": "سلبي",
        "Negative filled": "مرفوض نهائياً",
        "Warning": "تنبيه",
        "Warning filled": "تنبيه هام",
        "Brand": "رسمي",
        "Brand filled": "خدمة رسمية",
        "Prefix icon": "رمز في البداية",
        "Suffix icon": "رمز في النهاية",
        "Prefix + suffix": "رمزان",
        "Status list": "قائمة الحالات",
        "Application has been approved": "تم اعتماد الطلب رسمياً من قِبل اللجنة المختصة",
        "Awaiting reviewer decision": "بانتظار قرار فريق المراجعة والتدقيق",
        "Application could not be processed": "تعذر استكمال المعاملة لعدم اكتمال الوثائق",
        "Recently added service": "خدمة حكومية مضافة حديثاً إلى المنصة",

        // ── Banners ──
        "Success": "تمت العملية بنجاح",
        "Error": "خطأ في المعالجة",
        "Submitted": "تم إرسال الطلب بنجاح",
        "Payment failed": "فشلت عملية الدفع الإلكتروني",
        "Your application has been saved as a draft.": "تم حفظ طلبك كمسودة، يمكنك العودة واستكماله في أي وقت.",
        "Your changes have been saved.": "تم حفظ جميع التعديلات بنجاح في قاعدة البيانات.",
        "Your session will expire in five minutes.": "ستنتهي جلستك الحالية خلال خمس دقائق، يرجى حفظ عملك.",
        "We could not process your request. Please try again.": "تعذر إكمال طلبك حالياً، يرجى التحقق وإعادة المحاولة.",
        "The card was declined by the issuing bank.": "تم رفض البطاقة من قبل البنك المصدر، يرجى التأكد من الرصيد.",
        "A plain message with no leading icon.": "رسالة توضيحية بدون رمز أمامي.",
        "Unsaved changes": "تعديلات غير محفوظة",
        "You have changes that have not been submitted yet.": "لديك تعديلات مدخلة لم يتم إرسالها بعد.",
        "Close this banner to dismiss it.": "أغلق هذا التنبيه لإخفائه من الشاشة.",

        // ── Callout ──
        "Quote title": "رؤية عُمان ٢٠٤٠",
        "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.": "تهدف سلطنة عمان إلى بناء منظومة رقمية متقدمة واقتصاد معرفي مرن يخدم المواطنين والمقيمين والمستثمرين بأعلى درجات الكفاءة والموثوقية.",
        "- Author": "— المنصة الرقمية الموحدة (Gov.om)",
        "Clickable callout": "اقتباس تفاعلي قابل للنقر",
        "Click anywhere on this callout (or focus and press Enter/Space) to fire the OnClick event.": "انقر في أي مكان داخل هذا الصندوق لتنفيذ الإجراء البرمجي.",

        // ── Stepper ──
        "Business details": "بيانات المنشأة التجارية",
        "Premises": "مقر وموقع النشاط",
        "Documents": "الوثائق والمرفقات",
        "Review and submit": "المراجعة النهائية والإرسال",
        "Under review": "قيد التدقيق والمراجعة",
        "Decision": "إصدار القرار الرسمي",

        // ── Radio & Checkbox ──
        "Preferred contact method": "طريقة استلام الإشعارات المفضلة",
        "We'll send updates to your inbox.": "سنرسل إشعارات التحديث إلى بريدك الإلكتروني.",
        "SMS": "رسالة نصية قصيرة (SMS)",
        "We'll send a text to your phone.": "سنرسل رمز التأكيد إلى هاتفك النقال.",
        "Do not contact": "عدم استلام الرسائل الترويجية",
        "Application type": "نوع الطلب والمعاملة",
        "New application": "طلب تصريح جديد",
        "Apply for the first time.": "التقديم على هذه الخدمة للمرة الأولى.",
        "Renewal": "تجديد الترخيص السنوي",
        "Renew an existing permit.": "تجديد ترخيص أو تصريح مسجل مسبقاً.",
        "Replacement (unavailable)": "إصدار بدل فاقد (غير متاح)",
        "Do you own a vehicle?": "هل تمتلك مركبة مسجلة باسمك؟",
        "Yes": "نعم",
        "No": "لا",
        "I accept the terms and conditions": "أوافق على الشروط والأحكام واللوائح المعتمدة",
        "Please read the terms before accepting.": "يرجى قراءة الشروط والتعليمات التنظيمية قبل المتابعة.",
        "Subscribe to newsletter": "الاشتراك في النشرة الإخبارية الحكومية",
        "Enable notifications": "تفعيل التنبيهات الفورية عبر المنصة",
        "Toggle me — the bound value updates below.": "قم بالتبديل لتحديث الحالة المسجلة.",
        "Subscribe to product updates": "استلام مستجدات الخدمات الجديدة",

        // ── File Upload ──
        "Only .pdf .jpg or .png files at 5 MB or less.": "الملفات المدعومة: PDF أو JPG أو PNG بحجم لا يتجاوز ٥ ميجابايت.",
        "Pick a file — its metadata appears below.": "اختر ملفاً لرفع المستند والتحقق منه.",
        "No files selected.": "لم يتم اختيار أي مستند بعد.",
        "Files flow into C# via OnChange": "معالجة الملفات في الواجهة الخلفية"
    };

    function translateElement(root, isRtl) {
        if (!root || !root.querySelectorAll) return;

        // Traverse all child text nodes
        var walker = document.createTreeWalker(
            root,
            NodeFilter.SHOW_TEXT | NodeFilter.SHOW_ELEMENT,
            {
                acceptNode: function (node) {
                    if (node.nodeType === Node.ELEMENT_NODE) {
                        var tag = node.tagName.toLowerCase();
                        if (tag === 'code' || tag === 'pre' || tag === 'script' || tag === 'style') {
                            return NodeFilter.FILTER_REJECT;
                        }
                        if (node.classList && (node.classList.contains('doc-code') || node.classList.contains('demo-example-code'))) {
                            return NodeFilter.FILTER_REJECT;
                        }
                    }
                    return NodeFilter.FILTER_ACCEPT;
                }
            }
        );

        var node;
        while ((node = walker.nextNode())) {
            if (node.nodeType === Node.TEXT_NODE) {
                var raw = node.nodeValue;
                if (!raw) continue;

                if (isRtl) {
                    var trimmed = raw.trim();
                    if (!trimmed) continue;

                    if (node.__gupOrigText === undefined) {
                        var ar = DICTIONARY[trimmed];
                        if (ar) {
                            node.__gupOrigText = raw;
                            var leading = raw.match(/^\s*/)[0];
                            var trailing = raw.match(/\s*$/)[0];
                            node.nodeValue = leading + ar + trailing;
                        }
                    }
                } else {
                    if (node.__gupOrigText !== undefined) {
                        node.nodeValue = node.__gupOrigText;
                        delete node.__gupOrigText;
                    }
                }
            } else if (node.nodeType === Node.ELEMENT_NODE) {
                // Input and textarea placeholders
                if (node.placeholder !== undefined && node.placeholder !== '') {
                    if (isRtl) {
                        if (node.__gupOrigPlaceholder === undefined) {
                            var arPlaceholder = DICTIONARY[node.placeholder.trim()];
                            if (arPlaceholder) {
                                node.__gupOrigPlaceholder = node.placeholder;
                                node.placeholder = arPlaceholder;
                            }
                        }
                    } else {
                        if (node.__gupOrigPlaceholder !== undefined) {
                            node.placeholder = node.__gupOrigPlaceholder;
                            delete node.__gupOrigPlaceholder;
                        }
                    }
                }

                // Button value
                if (node.tagName === 'INPUT' && (node.type === 'button' || node.type === 'submit' || node.type === 'reset')) {
                    if (isRtl) {
                        if (node.__gupOrigValue === undefined) {
                            var arValue = DICTIONARY[node.value.trim()];
                            if (arValue) {
                                node.__gupOrigValue = node.value;
                                node.value = arValue;
                            }
                        }
                    } else {
                        if (node.__gupOrigValue !== undefined) {
                            node.value = node.__gupOrigValue;
                            delete node.__gupOrigValue;
                        }
                    }
                }
            }
        }
    }

    window.gupDemoDirection = {
        get: function () {
            try {
                var params = new URLSearchParams(window.location.search);
                var urlDir = params.get('dir');
                if (urlDir === 'rtl' || urlDir === 'ltr') {
                    localStorage.setItem('gup-demo-dir', urlDir);
                    return urlDir;
                }
                return localStorage.getItem('gup-demo-dir') || 'ltr';
            } catch (e) {
                return 'ltr';
            }
        },

        set: function (dir) {
            var normalized = (dir === 'rtl') ? 'rtl' : 'ltr';
            try {
                localStorage.setItem('gup-demo-dir', normalized);
            } catch (e) { }

            try {
                var url = new URL(window.location.href);
                if (normalized === 'rtl') {
                    url.searchParams.set('dir', 'rtl');
                } else {
                    url.searchParams.delete('dir');
                }
                window.history.replaceState({}, '', url.pathname + url.search + url.hash);
            } catch (e) { }

            window.gupDemoDirection.syncAll(normalized);
            window.dispatchEvent(new CustomEvent('gup-dir-changed', { detail: { dir: normalized } }));
            return normalized;
        },

        syncSurface: function (surface, dir) {
            if (!surface) return;
            var isRtl = (dir === 'rtl') || (surface.getAttribute && surface.getAttribute('dir') === 'rtl');
            translateElement(surface, isRtl);
        },

        syncAll: function (dir) {
            var isRtl = (dir === 'rtl');
            var surfaces = document.querySelectorAll('.demo-surface');
            for (var i = 0; i < surfaces.length; i++) {
                var s = surfaces[i];
                var sDir = isRtl ? 'rtl' : 'ltr';
                s.setAttribute('dir', sDir);
                if (isRtl) {
                    s.classList.add('demo-surface--rtl');
                } else {
                    s.classList.remove('demo-surface--rtl');
                }
                translateElement(s, isRtl);
            }
        },

        initKeyboard: function (dotNetHelper) {
            if (window._gupKeyboardAttached) return;
            window._gupKeyboardAttached = true;

            window.addEventListener('keydown', function (e) {
                if (e.altKey && !e.ctrlKey && !e.metaKey && (e.key === 'r' || e.key === 'R' || e.key === 'ق' || e.code === 'KeyR')) {
                    e.preventDefault();
                    if (dotNetHelper && dotNetHelper.invokeMethodAsync) {
                        dotNetHelper.invokeMethodAsync('ToggleFromKeyboard');
                    }
                }
            });
        }
    };

    // DOM MutationObserver to auto-translate any newly rendered or updated .demo-surface
    var observer = new MutationObserver(function (mutations) {
        for (var i = 0; i < mutations.length; i++) {
            var m = mutations[i];
            if (m.type === 'attributes' && m.attributeName === 'dir') {
                var target = m.target;
                if (target.classList && target.classList.contains('demo-surface')) {
                    var isRtl = target.getAttribute('dir') === 'rtl';
                    translateElement(target, isRtl);
                }
            } else if (m.type === 'childList' && m.addedNodes.length > 0) {
                var surface = (m.target.closest && m.target.closest('.demo-surface'));
                if (surface) {
                    var isRtlSurface = surface.getAttribute('dir') === 'rtl';
                    translateElement(surface, isRtlSurface);
                }
            }
        }
    });

    if (document.body) {
        observer.observe(document.body, { childList: true, subtree: true, attributes: true, attributeFilter: ['dir'] });
        // Initial sync on startup if dir=rtl is saved
        var initialDir = window.gupDemoDirection.get();
        if (initialDir === 'rtl') {
            setTimeout(function () {
                window.gupDemoDirection.syncAll('rtl');
            }, 100);
        }
    } else {
        document.addEventListener('DOMContentLoaded', function () {
            observer.observe(document.body, { childList: true, subtree: true, attributes: true, attributeFilter: ['dir'] });
            var initialDir = window.gupDemoDirection.get();
            if (initialDir === 'rtl') {
                setTimeout(function () {
                    window.gupDemoDirection.syncAll('rtl');
                }, 100);
            }
        });
    }
})();
