Luxe Studio

A one-page website for Luxe Studio, a hair, nails and beauty salon in Nairobi, Kenya. Customers can see services and prices, apply a coupon, order or book on WhatsApp, read reviews, check the FAQ and find the salon on the map.
Live site:https://github.com/Nowie4678/Luxe_Studio
What the website does
Services and product listing with an order box and coupon codes (LUXE10 = 10% off, WELCOME15 = 15% off)
WhatsApp ordering and booking: the customer's order opens in WhatsApp, addressed to the salon
Booking form with spam protection and an on-page thank-you message
Customer reviews and a FAQ section
Privacy Policy and Terms & Conditions pop-ups
Meet-the-team section, Google Map with directions, and direct call / WhatsApp / email buttons
Chat assistant (simple rule-based, answers prices, hours, booking, discounts, location)
Light theme by default (white, purple headings, black text) and a dark mode toggle (midnight black and rose gold)
Cookie consent banner, scroll-to-top button, loading spinner, favicon, mobile-friendly layout, social preview tags
#	Problem	Cause	Solution
1	"FAQ not found", "Reviews not found", and Terms & Conditions gave "page not found"	FAQ, reviews, privacy, terms and thank-you were separate .html files, and only some of the files had been saved or uploaded	Merged everything into one index.html. FAQ and Reviews became sections, Privacy and Terms became pop-ups, and the thank-you message appears on the same page after booking
I did not like the purple background and the purple/gold dark mode	A purple page with white text was too heavy to read, and gold on purple looked harsh	Changed to a white page with purple headings and black text. Dark mode is now midnight black with rose gold
	Coupon order message arrived on my own phone	That is how it works: the order is addressed to the salon number, so it reaches the owner. I was testing with the same number
  GitHub Pages branch showed None	The files were not committed, so the repository had no branch to publish	Uploaded the files, clicked Commit changes, then chose master and / (root) under Settings -> Pages
  Desktop app (Luxe Studio management system, C# Windows Forms)
Problem	Solution
Login showed "Invalid column name Email / Password"	The Users table columns did not match the code. Recreated the table with Email and Password columns
Dashboard showed "Invalid column name AppointmentDate"	Created the Clients, Services, Appointments and Billing tables with the exact column names the code uses
Needed to connect to the .mdf database file	Used a LocalDB connection string with AttachDbFilename pointing to the database file
Notes and limits
The site has no server. Bookings are sent through WhatsApp, not stored in a database.
Coupon codes are visible in script.js, so they are not secret.
Reviews are saved only in the visitor's own browser.
Contact

Luxe Studio, Nairobi, Kenya Phone / WhatsApp: 0723 567 812 Email: luxestudio@gmail.com
