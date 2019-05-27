# Tangy-Restaurant Description
- This is a simple restaurant application build with .NET Core MVC and Bootstrap with Font Awesome for styling.
- The app uses External logins, Two factor authentication, paginations, verification emails, Typeahead and more.
- Some images are saved on the database, while others are stored on the server, both methods are displayed.
- It has a home page which is displaying changing coupons and a list of menu items available in the restaurant.
- The menu items contain a description and are organized by categories, subcategories and tags.
- There is a "Details" page for menu items from where a logged in user can add a menu item to his shopping cart.
- The "Manage Orders" page is used by shef to update the status of an order and move it along.
- An order has 4 deferent statuses: 
	01. Submitted - When the order is placed but no shef is working on it yet. (Manage Orders page)
	02. Being prepared - When the order is being prepared by a shef. (Manage Orders page)
	03. Order prepared - When the order is prepared. (Manage Orders page)
	04. Ready for pick up - When the order is ready to be picked up by the client (Order Pickup page)
	05. Competed - When an order is picked up and confirmed by the admin. (Order Pickup Details page)

- A full description of the application is available in the README.md file.
- The "Order Pickup" page is used by the store colleagues, here is where all orders are ready to be picked up.
- There is a "Search Criteria" section where a colleague can search by Order Id, Email or Phone number using Typeahead.
- When an order is picked up by the client, the store colleague gets redirected to the "Confirm Details" page 
- he/she sees all the information about that order and confirm it.
- After an order is confirmed and picked up, it's status changes to "Completed".
	
- Tangy-Restaurant contains a login and registration pages.
- A "Manage Your Account" page is available for users to change their personal details.
- A logged in user can view an "Order History" page containing past orders and "Shopping Cart" page which he can fill with menu items.
- From the "Shopping Cart" page a user can create and order by entering comments, pickup time and a coupon code.
- Once a user creates an order, he/she gets redirected to a confirmation page with all details about the order.
- When the order is placed, it shows into the "Order History" page.	
- An administrator can see additional tabs on the navigation, he can manage and perform CRUD operations on 
- categories, subcategories, coupons, menu items and more.
- Admins have credentials to lock/unlock users and add details about the reason why.


	