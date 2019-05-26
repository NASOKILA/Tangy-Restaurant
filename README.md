# Tangy-Restaurant Description
	This is a simple restaurant application build with .NET Core MVC and Bootstrap with Font Awesome for styling.
	The app uses External logins, Two factor authentication, paginations, verification emails, typeahead and more.
	Part of the images used are saved on the database, while others are stored on the server, both methods are displayed.
	It has a home page which is displaying changing coupons and a list of menu items avaliable in the restaurant.
	The menu items contain a description and are organised by categories, subcategories and tags.
	There is a "Details" page for menu items from where a logged in user can add a menu item to his shopping cart.
	The "Manage Orders" page is used by sheffs to update the state of an order and move it along.
	An order has 4 deferent statuses: 
		01.Submitted - When the order is placed but no sheff is working on it yet. (Manage Orders page)
		02.Beign prepared - When the order is being prepared by a sheff. (Manage Orders page)
		03.Order prepared - When the order is prepared. (Manage Orders page)
		04.Ready for pick up - When the order is ready to be picked up by the client (Order Pickup page)
		05.Competed - When an order is picked up by the client and is confirmed by the administrator. ( Order Pickup Details page)
		
	The "Order Pickup" page is used by the store colleagues, here is where all orders are ready to be picked up.
	There is a "Seach Criteria" section where a colleague can search by Order Id, Email or Phone number 
	using typeahead.
	When an order is picked up by the cliend, the store colleague gets redirected to the "Confirm Details" page 
	where he/she sees all the information about that order and confirm it.
	After an order is confirmed and picked up, it's status changes to "Completed".
	
	Tangy-Rstaurant contains a login and registration pages.
	A "Manage Your Account" page is avaliable for users to change their personal details.
	A logged in user can view an "Order History" page containing past orders and "Shopping Cart" page which he 
	can fill with menu items.
	From the "Shopping Cart" page a user can create and order by entering comments, pickup time and a coupon code.
	Once a user creates an order, he/she gets redirected to a confirmation page with all details about the order.
	When the order is placed, it shows into the "Order History" page.
	
	An administrator can see additional tabs on the navigation, he can manage and perform CRUD operations on 
	the categories, subcategories, coupons, menuitems and more.
	Admins have credentials to lock/unlock users and add details about the reason why.
	

	