/* ===== Luxe Studio - script.js ===== */
(function () {
    "use strict";

    /* ---------- SETTINGS: edit these ---------- */
    var CONFIG = {
        name: "Luxe Studio",
        email: "luxestudio@gmail.com",
        phoneDisplay: "0723 567 812",
        phoneTel: "+254723567812",
        whatsapp: "254723567812",                 // international format, no + or 0
        address: "Nairobi CBD, Kenya",            // TODO: put your real street address
        mapQuery: "Nairobi CBD, Kenya",           // TODO: same, or your Google Maps place name
        hours: "Mon-Sat 8:00AM - 8:00PM, Sun 9:00AM - 5:00PM",   // TODO: your real hours
        coupons: { "LUXE10": 10, "WELCOME15": 15 },               // code : percent off
        maxBookingsPerHour: 3
    };

    var IMG = {
        hero: "https://images.unsplash.com/photo-1560066984-138dadb4c035?auto=format&fit=crop&w=900&q=70",
        hair: "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?auto=format&fit=crop&w=600&q=70",
        braids: "https://images.unsplash.com/photo-1522335789203-aabd1fc54bc9?auto=format&fit=crop&w=600&q=70",
        cut: "https://images.unsplash.com/photo-1562322140-8baeececf3df?auto=format&fit=crop&w=600&q=70",
        nails: "https://images.unsplash.com/photo-1604654894610-df63bc536371?auto=format&fit=crop&w=600&q=70",
        makeup: "https://images.unsplash.com/photo-1487412947147-5cebf100ffc2?auto=format&fit=crop&w=600&q=70",
        facial: "https://images.unsplash.com/photo-1570172619644-dfd03ed5d881?auto=format&fit=crop&w=600&q=70"
    };

    var PRODUCTS = [
        { id: 1, name: "Braiding Package", price: 2500, img: IMG.braids, desc: "Knotless, box or cornrows" },
        { id: 2, name: "Haircut & Style", price: 800, img: IMG.cut, desc: "Cut, wash and blow-dry" },
        { id: 3, name: "Gel Manicure", price: 1200, img: IMG.nails, desc: "Long-lasting shine" },
        { id: 4, name: "Glow Facial", price: 3000, img: IMG.facial, desc: "Deep clean and hydrate" },
        { id: 5, name: "Bridal Makeup", price: 6000, img: IMG.makeup, desc: "Your big day, flawless" },
        { id: 6, name: "Hair Treatment", price: 2000, img: IMG.hair, desc: "Repair and shine" }
    ];

    var JOKES = [
        "Why did the hair stylist win the race? She knew all the short cuts!",
        "I told my hairdresser I wanted to look like a million bucks. She gave me a trim and a bill for the rest!",
        "Why don't nails ever get lost? They always know where they're filed!",
        "A great hair day is just a bad hair day that visited Luxe Studio."
    ];

    var STYLISTS = [
        { name: "Grace Achieng", phone: "0712345678", role: "Stylist" },
        { name: "Joy Wambui", phone: "0723456789", role: "Stylist" },
        { name: "Faith Mwende", phone: "0734567890", role: "Receptionist" },
        { name: "Brian Otieno", phone: "0745678901", role: "Manager" },
        { name: "Cathy", phone: "0765432719", role: "Stylist" }
    ];

    /* ---------- helpers ---------- */
    function $(s, r) { return (r || document).querySelector(s); }
    function $$(s, r) { return Array.prototype.slice.call((r || document).querySelectorAll(s)); }
    function esc(t) {
        var d = document.createElement("div");
        d.textContent = t == null ? "" : String(t);
        return d.innerHTML;
    }
    function store(key, val) {
        try { if (val === undefined) { return JSON.parse(localStorage.getItem(key)); } localStorage.setItem(key, JSON.stringify(val)); } catch (e) { return null; }
    }
    function waLink(text) { return "https://wa.me/" + CONFIG.whatsapp + "?text=" + encodeURIComponent(text); }
    function kes(n) { return "KES " + Number(n).toLocaleString("en-KE"); }

    /* ---------- force HTTPS (also set in .htaccess) ---------- */
    if (location.protocol === "http:" && !/^(localhost|127\.|192\.168\.)/.test(location.hostname)) {
        location.replace("https://" + location.host + location.pathname + location.search + location.hash);
        return;
    }

    /* ---------- preloader ---------- */
    var pre = document.createElement("div");
    pre.id = "preloader";
    pre.innerHTML = '<div class="spinner"></div><strong>' + CONFIG.name + "</strong>";
    document.documentElement.appendChild(pre);
    function hidePre() { pre.classList.add("hide"); setTimeout(function () { pre.remove(); }, 500); }
    window.addEventListener("load", hidePre);
    setTimeout(hidePre, 4000);   // never get stuck

    /* ---------- theme toggle (saved) ---------- */
    var savedTheme = store("luxe-theme");
    if (savedTheme === "dark") document.documentElement.setAttribute("data-theme", "dark");

    /* ---------- header, footer, breadcrumbs ---------- */
    function navLink(href, label) { return '<li><a href="' + href + '">' + label + "</a></li>"; }
    var headerHTML =
        '<header class="site-header"><div class="container nav">' +
        '<a class="logo" href="#">LUXE <span>STUDIO</span></a>' +
        '<button class="menu-btn" id="menuBtn" aria-label="Open menu">&#9776;</button>' +
        '<ul class="nav-links" id="navLinks">' +
        navLink("#", "Home") + navLink("#services", "Services") +
        navLink("#team", "Team") + navLink("#reviews", "Reviews") +
        navLink("#faq", "FAQ") + navLink("#location", "Contact") +
        '<li><label class="switch" title="Dark / light mode"><input type="checkbox" id="themeToggle" aria-label="Toggle dark mode"><span class="slider"></span></label></li>' +
        '<li><a class="btn btn-sm" href="#book">Book Now</a></li>' +
        "</ul></div></header>";

    var footerHTML =
        "<footer><div class=\"container\"><div class=\"foot-grid\">" +
        "<div><h4>Luxe Studio</h4><p>Beauty that makes you feel like royalty.</p></div>" +
        "<div><h4>Quick links</h4><a href=\"#services\">Services</a><a href=\"#reviews\">Reviews</a><a href=\"#faq\">FAQ</a></div>" +
        "<div><h4>Legal</h4><a href=\"#\" data-modal=\"privacyModal\">Privacy Policy</a><a href=\"#\" data-modal=\"termsModal\">Terms &amp; Conditions</a></div>" +
        "<div><h4>Contact</h4><a href=\"tel:" + CONFIG.phoneTel + "\">" + CONFIG.phoneDisplay + "</a>" +
        "<a href=\"mailto:" + CONFIG.email + "\">" + CONFIG.email + "</a><p>" + esc(CONFIG.address) + "</p></div>" +
        "</div><p class=\"copy\">&copy; " + new Date().getFullYear() + " " + CONFIG.name + ". All rights reserved.</p></div></footer>";

    var h = $("#site-header"); if (h) h.innerHTML = headerHTML;
    var f = $("#site-footer"); if (f) f.innerHTML = footerHTML;

    var menuBtn = $("#menuBtn"), navLinks = $("#navLinks");
    if (menuBtn && navLinks) {
        menuBtn.addEventListener("click", function () { navLinks.classList.toggle("open"); });
        $$("a", navLinks).forEach(function (a) { a.addEventListener("click", function () { navLinks.classList.remove("open"); }); });
    }

    var themeToggle = $("#themeToggle");
    if (themeToggle) {
        themeToggle.checked = savedTheme === "dark";
        themeToggle.addEventListener("change", function () {
            var dark = themeToggle.checked;
            if (dark) document.documentElement.setAttribute("data-theme", "dark");
            else document.documentElement.removeAttribute("data-theme");
            store("luxe-theme", dark ? "dark" : "light");
        });
    }

    /* ---------- pop-ups (privacy, terms) ---------- */
    document.addEventListener("click", function (e) {
        var opener = e.target.closest("[data-modal]");
        if (opener) {
            e.preventDefault();
            var dlg = document.getElementById(opener.getAttribute("data-modal"));
            if (dlg && dlg.showModal) dlg.showModal();
            return;
        }
        if (e.target.closest("[data-close]")) { e.target.closest("dialog").close(); return; }
        if (e.target.tagName === "DIALOG") e.target.close();   // click on the dark backdrop
    });

    /* ---------- floating buttons: WhatsApp, call, scroll-to-top ---------- */
    var fabs = document.createElement("div");
    fabs.innerHTML =
        '<a id="waFab" class="fab" target="_blank" rel="noopener" aria-label="Chat on WhatsApp" href="' +
        waLink("Hello Luxe Studio, I would like to make an enquiry.") + '"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M12 2a10 10 0 0 0-8.6 15.1L2 22l5-1.3A10 10 0 1 0 12 2zm5.3 14.2c-.2.6-1.3 1.2-1.8 1.2-.5.1-1 .2-3.3-.7-2.8-1.1-4.6-3.9-4.7-4.1-.1-.2-1.1-1.4-1.1-2.7s.7-1.9.9-2.2c.2-.3.5-.3.7-.3h.5c.2 0 .4 0 .6.5l.8 2c.1.2.1.4 0 .6l-.4.6c-.1.2-.3.3-.1.6.2.3.8 1.3 1.7 2 1.1 1 2 1.3 2.3 1.4.3.1.5.1.6-.1l.9-1.1c.2-.3.4-.2.6-.1l1.9.9c.3.1.5.2.6.3.1.3.1.9-.1 1.4z"/></svg></a>' +
        '<a id="callFab" class="fab" aria-label="Call us" href="tel:' + CONFIG.phoneTel + '"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M6.6 10.8a15 15 0 0 0 6.6 6.6l2.2-2.2a1 1 0 0 1 1-.25c1.1.37 2.3.57 3.6.57a1 1 0 0 1 1 1V20a1 1 0 0 1-1 1A17 17 0 0 1 3 4a1 1 0 0 1 1-1h3.5a1 1 0 0 1 1 1c0 1.25.2 2.45.57 3.57a1 1 0 0 1-.25 1z"/></svg></a>' +
        '<button id="toTop" class="fab" aria-label="Scroll to top"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M12 5l8 9h-5v5H9v-5H4z"/></svg></button>';
    document.body.appendChild(fabs);
    var toTop = $("#toTop");
    window.addEventListener("scroll", function () { toTop.style.display = window.scrollY > 400 ? "flex" : "none"; });
    toTop.addEventListener("click", function () { window.scrollTo({ top: 0, behavior: "smooth" }); });

    /* ---------- images: hide broken ones so the gradient shows ---------- */
    document.addEventListener("error", function (e) {
        if (e.target && e.target.tagName === "IMG") e.target.classList.add("img-fail");
    }, true);

    /* ---------- cookie consent ---------- */
    if (!store("luxe-cookies")) {
        var bar = document.createElement("div");
        bar.id = "cookieBar";
        bar.innerHTML = "<span>We use cookies to remember your settings and improve the site. See our <a href=\"#\" data-modal=\"privacyModal\">Privacy Policy</a>.</span>" +
            '<span><button class="btn btn-sm" id="ckYes">Accept</button> <button class="btn btn-sm btn-outline" id="ckNo">Decline</button></span>';
        document.body.appendChild(bar);
        bar.style.display = "flex";
        $("#ckYes").onclick = function () { store("luxe-cookies", "accepted"); bar.remove(); };
        $("#ckNo").onclick = function () { store("luxe-cookies", "declined"); bar.remove(); };
    }

    /* ---------- AI-style chatbot (simple rules, no server) ---------- */
    var chatBtn = document.createElement("button");
    chatBtn.id = "chatFab"; chatBtn.className = "fab"; chatBtn.setAttribute("aria-label", "Open chat assistant");
    chatBtn.innerHTML = '<svg viewBox="0 0 24 24" aria-hidden="true"><path d="M4 3h16a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H9l-5 4v-4H4a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2z"/></svg>';
    var chat = document.createElement("div");
    chat.id = "chatBox";
    chat.innerHTML =
        '<div class="chat-head"><span>Luxe Assistant</span><button id="chatClose" aria-label="Close chat">&#10005;</button></div>' +
        '<div id="chatLog"></div>' +
        '<div class="chat-quick"><button>Prices</button><button>Opening hours</button><button>Book</button><button>Discount</button><button>Location</button></div>' +
        '<form class="chat-form" id="chatForm"><input id="chatIn" placeholder="Type your question..." autocomplete="off" maxlength="200"><button class="btn btn-sm" type="submit">Send</button></form>';
    document.body.appendChild(chatBtn);
    document.body.appendChild(chat);

    function botSay(t, me) {
        var b = document.createElement("div");
        b.className = "bubble " + (me ? "me" : "bot");
        b.innerHTML = t;
        $("#chatLog").appendChild(b);
        $("#chatLog").scrollTop = 99999;
    }
    function reply(q) {
        q = q.toLowerCase();
        if (/price|cost|how much|charge|rate/.test(q)) {
            return "Our popular prices: " + PRODUCTS.map(function (p) { return p.name + " " + kes(p.price); }).join(", ") + ".";
        }
        if (/hour|open|close|time/.test(q)) return "We are open " + esc(CONFIG.hours) + ".";
        if (/book|appointment|reserve/.test(q)) return 'You can book in a minute using the <a href="#book">booking form</a>, or <a href="' + waLink("Hello, I would like to book an appointment.") + '" target="_blank" rel="noopener">WhatsApp us</a>.';
        if (/discount|coupon|offer|promo|code/.test(q)) return "Use code <b>LUXE10</b> for 10% off, or <b>WELCOME15</b> for 15% off your first visit. Enter it in the order box on the home page.";
        if (/where|location|address|direction|map/.test(q)) return "We are at " + esc(CONFIG.address) + '. <a href="#location">See the map and directions</a>.';
        if (/stylist|who|team|manager/.test(q)) return "Our team: " + STYLISTS.map(function (s) { return s.name + " (" + s.role + ")"; }).join(", ") + ".";
        if (/phone|call|contact|email|support|help/.test(q)) return 'Call <a href="tel:' + CONFIG.phoneTel + '">' + CONFIG.phoneDisplay + '</a> or email <a href="mailto:' + CONFIG.email + '">' + CONFIG.email + "</a>.";
        if (/cancel|resched|change/.test(q)) return "To cancel or change a booking, please call or WhatsApp us at least 24 hours before your appointment.";
        if (/hi|hello|hey|habari|jambo/.test(q)) return "Hello and karibu! Ask me about prices, hours, booking, discounts or our location.";
        return "I am not sure about that one. Please call " + CONFIG.phoneDisplay + " or WhatsApp us and our team will help.";
    }
    chatBtn.addEventListener("click", function () {
        chat.classList.toggle("open");
        if (!$("#chatLog").children.length) botSay("Hi! I am the Luxe assistant. Ask me about prices, hours, booking, discounts or our location.");
    });
    $("#chatClose").addEventListener("click", function () { chat.classList.remove("open"); });
    $("#chatForm").addEventListener("submit", function (e) {
        e.preventDefault();
        var v = $("#chatIn").value.trim();
        if (!v) return;
        botSay(esc(v), true);
        $("#chatIn").value = "";
        setTimeout(function () { botSay(reply(v)); }, 350);
    });
    $$(".chat-quick button").forEach(function (b) {
        b.addEventListener("click", function () { botSay(esc(b.textContent), true); setTimeout(function () { botSay(reply(b.textContent)); }, 300); });
    });

    /* ---------- HOME PAGE ONLY ---------- */

    // joke
    var jokeEl = $("#jokeText");
    if (jokeEl) {
        var ji = Math.floor(Math.random() * JOKES.length);
        jokeEl.textContent = JOKES[ji];
        $("#jokeBtn").addEventListener("click", function () { ji = (ji + 1) % JOKES.length; jokeEl.textContent = JOKES[ji]; });
    }

    // hero image
    var heroImg = $("#heroImg"); if (heroImg) heroImg.src = IMG.hero;

    // products + order (WhatsApp) + coupon
    var grid = $("#productGrid");
    if (grid) {
        var cart = {}, discount = 0;
        grid.innerHTML = PRODUCTS.map(function (p) {
            return '<div class="card"><img src="' + p.img + '" alt="' + esc(p.name) + '" loading="lazy" width="600" height="400">' +
                '<div class="card-body"><h3>' + esc(p.name) + "</h3><p>" + esc(p.desc) + '</p><div class="price">' + kes(p.price) +
                '</div><button class="btn btn-sm" data-add="' + p.id + '">Add to order</button></div></div>';
        }).join("");

        var lines = $("#orderLines"), totalsEl = $("#orderTotals"), couponMsg = $("#couponMsg"), waBtn = $("#orderWA");
        function renderCart() {
            var ids = Object.keys(cart), subtotal = 0, text = "";
            if (!ids.length) {
                lines.innerHTML = "<p>Your order is empty. Add something above.</p>";
                totalsEl.innerHTML = ""; waBtn.style.display = "none"; return;
            }
            lines.innerHTML = ids.map(function (id) {
                var p = PRODUCTS.filter(function (x) { return x.id == id; })[0];
                var line = p.price * cart[id]; subtotal += line;
                text += "- " + p.name + " x" + cart[id] + " = " + kes(line) + "\n";
                return '<div class="order-line"><span>' + esc(p.name) + '</span><span class="qty"><button data-minus="' + id + '">-</button> ' + cart[id] +
                    ' <button data-plus="' + id + '">+</button></span><span>' + kes(line) + "</span></div>";
            }).join("");
            var off = Math.round(subtotal * discount / 100), total = subtotal - off;
            totalsEl.innerHTML = "Subtotal: " + kes(subtotal) + (discount ? "<br>Discount (" + discount + "%): -" + kes(off) : "") + "<br><strong>Total: " + kes(total) + "</strong>";
            var msg = "Hello Luxe Studio, I would like to order:\n" + text + (discount ? "Coupon: " + $("#couponIn").value.trim().toUpperCase() + " (" + discount + "% off)\n" : "") + "Total: " + kes(total);
            waBtn.href = waLink(msg); waBtn.style.display = "inline-block";
        }
        grid.addEventListener("click", function (e) {
            var id = e.target.getAttribute("data-add");
            if (id) { cart[id] = (cart[id] || 0) + 1; renderCart(); }
        });
        lines.addEventListener("click", function (e) {
            var plus = e.target.getAttribute("data-plus"), minus = e.target.getAttribute("data-minus");
            if (plus) cart[plus]++;
            if (minus) { cart[minus]--; if (cart[minus] <= 0) delete cart[minus]; }
            renderCart();
        });
        $("#couponBtn").addEventListener("click", function () {
            var code = $("#couponIn").value.trim().toUpperCase();
            if (CONFIG.coupons[code]) {
                discount = CONFIG.coupons[code];
                couponMsg.className = "msg-ok"; couponMsg.textContent = "Coupon applied: " + discount + "% off!";
            } else {
                discount = 0; couponMsg.className = "msg-bad"; couponMsg.textContent = "Invalid coupon code.";
            }
            renderCart();
        });
        renderCart();
    }

    // team
    var team = $("#teamGrid");
    if (team) {
        team.innerHTML = STYLISTS.map(function (s) {
            return '<div class="card"><div class="card-body"><div class="avatar">' + esc(s.name.charAt(0)) + "</div><h3>" + esc(s.name) +
                '</h3><p class="role">' + esc(s.role) + '</p><a class="btn btn-sm" href="tel:' + s.phone + '">Call ' + esc(s.phone) + "</a></div></div>";
        }).join("");
        var stylistSel = $("#bStylist");
        if (stylistSel) {
            STYLISTS.filter(function (s) { return s.role === "Stylist"; }).forEach(function (s) {
                var o = document.createElement("option"); o.value = s.name; o.textContent = s.name; stylistSel.appendChild(o);
            });
        }
    }

    // service dropdown + today as min date
    var svc = $("#bService");
    if (svc) {
        PRODUCTS.forEach(function (p) { var o = document.createElement("option"); o.value = p.name; o.textContent = p.name + " - " + kes(p.price); svc.appendChild(o); });
        var d = $("#bDate"); if (d) d.min = new Date().toISOString().split("T")[0];
    }

    // location links
    var mapFrame = $("#mapFrame");
    if (mapFrame) {
        mapFrame.src = "https://www.google.com/maps?q=" + encodeURIComponent(CONFIG.mapQuery) + "&output=embed";
        $("#dirBtn").href = "https://www.google.com/maps/dir/?api=1&destination=" + encodeURIComponent(CONFIG.mapQuery);
        $$(".js-address").forEach(function (el) { el.textContent = CONFIG.address; });
        $$(".js-hours").forEach(function (el) { el.textContent = CONFIG.hours; });
    }

    // booking form + spam protection
    var loadedAt = Date.now();
    var bookForm = $("#bookForm");
    if (bookForm) {
        function showThanks(b) {
            $("#bookingSummary").innerHTML = "<p><b>Name:</b> " + esc(b.name) + "</p><p><b>Phone:</b> " + esc(b.phone) + "</p><p><b>Service:</b> " + esc(b.service) +
                "</p><p><b>Stylist:</b> " + esc(b.stylist) + "</p><p><b>Date:</b> " + esc(b.date) + " " + esc(b.time) + "</p>" + (b.notes ? "<p><b>Notes:</b> " + esc(b.notes) + "</p>" : "");
            $("#confirmWA").href = waLink("Hello Luxe Studio, I would like to confirm my booking:\nName: " + b.name + "\nPhone: " + b.phone + "\nService: " + b.service +
                "\nStylist: " + b.stylist + "\nDate: " + b.date + " " + b.time + (b.notes ? "\nNotes: " + b.notes : ""));
            bookForm.style.display = "none";
            $("#thanks").style.display = "block";
            $("#thanks").scrollIntoView({ behavior: "smooth", block: "center" });
        }
        $("#anotherBtn").addEventListener("click", function () {
            bookForm.reset(); $("#bookMsg").textContent = ""; loadedAt = Date.now();
            $("#thanks").style.display = "none"; bookForm.style.display = "block";
            bookForm.scrollIntoView({ behavior: "smooth", block: "center" });
        });
        bookForm.addEventListener("submit", function (e) {
            e.preventDefault();
            var msg = $("#bookMsg"); msg.className = "form-msg msg-bad";

            // 1. honeypot: bots fill the hidden field
            if ($("#bWebsite").value) { return; }
            // 2. too fast to be human
            if (Date.now() - loadedAt < 3000) { msg.textContent = "Please take a moment to fill the form."; return; }
            // 3. rate limit
            var hist = (store("luxe-book-hist") || []).filter(function (t) { return Date.now() - t < 3600000; });
            if (hist.length >= CONFIG.maxBookingsPerHour) { msg.textContent = "Too many requests. Please try again later or call us."; return; }
            // 4. validation
            var name = $("#bName").value.trim(), phone = $("#bPhone").value.replace(/[\s-]/g, "");
            if (name.length < 2) { msg.textContent = "Please enter your name."; return; }
            if (!/^(\+?254|0)[17]\d{8}$/.test(phone)) { msg.textContent = "Enter a valid Kenyan phone number, e.g. 0712345678."; return; }
            if (!svc.value || !$("#bDate").value) { msg.textContent = "Please choose a service and a date."; return; }

            hist.push(Date.now()); store("luxe-book-hist", hist);
            showThanks({
                name: name, phone: phone, service: svc.value, stylist: $("#bStylist").value || "Any stylist",
                date: $("#bDate").value, time: $("#bTime").value, notes: $("#bNotes").value.trim().slice(0, 300)
            });
        });
    }

    /* ---------- REVIEWS PAGE ---------- */
    var revList = $("#reviewList");
    if (revList) {
        var seed = [
            { name: "Amina W.", stars: 5, text: "Best braids I have ever had. Grace was so patient and the salon is spotless!" },
            { name: "Sharon K.", stars: 5, text: "Joy did my gel manicure and it lasted three weeks. Will be back." },
            { name: "Mercy N.", stars: 4, text: "Lovely service and friendly team. Booking on WhatsApp was easy." }
        ];
        function showReviews() {
            var all = (store("luxe-reviews") || []).concat(seed);
            revList.innerHTML = all.map(function (r) {
                return '<div class="card review"><div class="card-body"><div class="stars">' + "&#9733;".repeat(r.stars) + "&#9734;".repeat(5 - r.stars) +
                    "</div><p>" + esc(r.text) + "</p><small>- " + esc(r.name) + "</small></div></div>";
            }).join("");
        }
        showReviews();
        var rl = Date.now();
        $("#reviewForm").addEventListener("submit", function (e) {
            e.preventDefault();
            var m = $("#revMsg"); m.className = "form-msg msg-bad";
            if ($("#rWebsite").value) return;                       // honeypot
            if (Date.now() - rl < 3000) { m.textContent = "Please take a moment before sending."; return; }
            var name = $("#rName").value.trim(), text = $("#rText").value.trim(), stars = parseInt($("#rStars").value, 10);
            if (name.length < 2 || text.length < 10) { m.textContent = "Please add your name and a short review (10+ characters)."; return; }
            var list = store("luxe-reviews") || [];
            list.unshift({ name: name.slice(0, 40), text: text.slice(0, 400), stars: stars });
            store("luxe-reviews", list.slice(0, 20));
            this.reset(); m.className = "form-msg msg-ok"; m.textContent = "Thank you for your review!";
            showReviews();
        });
    }
})();