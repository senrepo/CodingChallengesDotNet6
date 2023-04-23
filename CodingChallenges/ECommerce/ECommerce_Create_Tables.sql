/*
	Database Design Approach

	Step 1 - Take one main flow and think through
	Step 2 -Identify the Entity and Properties
	Step 3 - Relationship
	Step 4 - Indexing and Optimization

*/

/*
	Step 1 : Main flow
		Customer seaching the products in the catelog
		Add to shopping cart
		Place an order
		Order gets fullfilled/rejected
		Order gets Billed
		Order shipped
*/

/* Step 2: Entities and Properties
		Products -> ProductId, Name, Price
		Inventory -> ProductId, Qty
		Cart -> CartId, CustomerId, ProductId, Qty
		Customers -> CustomerId, Address, City, State, Country, Zip
		Orders -> OrderId, CustomerId, OrderDate, OrderStatus
		OrderDetails -> OrderId, ProductId, UnitPrice, Qty, DiscountCode
		Billing -> BillingId, OrderId, BilledAmt, BilledDate, BillMethod
		Shipping -> ShippingId, OrderId, CareerCode, Tracking, Status
*/


/*
	Step3 : Relationship
	Products
		ProductId is primary key
	Customers
		CustomerId is primary key
	Inventory
		ProductId is primary key
		Inventory.ProductId has a foreign key relationship with Products.ProductId
	Cart
		CartId is the primary key
		Cart.CustomerID has a foreign key relationship with Customers.CustomerId
		Cart.ProductId has a foreign key relationship with Products.ProductId
	Orders
		Orders.CustomerId has a foreign key relationship with Customers.CustomerId
	OrderDetails
		OrderId and Product is the primary key
		OrderDetails.OrderId has a foreign key relationship with Order.OrderId
		OrderDetails.ProductId has a foreign key relationship with Products.ProductId
	Billing
		BillingId is the primary key
		Billing.OrderId has a foreign key relationship with Orders.OrderId
	Shipping
		ShippingId is the primary key
		Shipping.OrderId has a foreign key relationship with Orders.OrderId
*/

USE Ecommerce;

/* Product Table */

CREATE TABLE Products (
	ProductId int Primary Key,
	ProductName varchar(200) not null,
	Price decimal(6,2) -- 1000.00 
);

/*Customer Table */
--Customers -> CustomerId, Address, City, State, Country, Zip
CREATE TABLE Customers (
	CustomerId int primary key,
	Address varchar(100),
	City varchar(50),
	State varchar(50),
	Country varchar(50),
	ZipCode varchar(50),
);

/*Inventory
Inventory -> ProductId, Qty
		ProductId is primary key
		Inventory.ProductId has a foreign key relationship with Products.ProductId
*/
CREATE TABLE Inventory(
	ProductId int Primary Key,
	Qty int,
	Constraint fkInventory Foreign key (ProductId) references Products(ProductId)
);

/*
Cart -> CartId, CustomerId, ProductId, Qty
	Cart
		CartId is the primary key
		Cart.CustomerID has a foreign key relationship with Customers.CustomerId
		Cart.ProductId has a foreign key relationship with Products.ProductId
*/

CREATE TABLE Cart(
	CartId int not null,
	CustomerId int not null,
	ProductId int not null,
	Qty int not null,
	Constraint pkCart primary key(CartId,CustomerId,ProductId),
	Constraint fkCartCustomer foreign key (CustomerId) references Customers(CustomerId),
	Constraint fkCartProduct foreign key (ProductId) references Products(ProductId) 
);

/*Orders
Orders -> OrderId, CustomerId, OrderDate, OrderStatus
	Orders
		Orders.CustomerId has a foreign key relationship with Customers.CustomerId
*/
CREATE TABLE Orders(
	OrderId int Primary key,
	CustomerId int not null,
	OrderDate DATETIME not null DEFAULT GETDATE(),
	OrderStatus varchar(100),
	Constraint fkOrdersCustId foreign key (CustomerId) references Customers(CustomerId)
);


/* OrderDetails -> OrderId, ProductId, UnitPrice, Qty, DiscountCode
	OrderDetails
		OrderId and Product is the primary key
		OrderDetails.OrderId has a foreign key relationship with Order.OrderId
		OrderDetails.ProductId has a foreign key relationship with Products.ProductId
*/
CREATE TABLE OrderDetails(
	OrderId int,
	ProductId int,
	UnitPrice decimal(6,2),
	Quantity int,
	DiscountCode varchar(100),
	constraint pkOrderDetails primary key(OrderId,ProductId) ,
	Constraint fkOrderDetailsOrderId foreign key (OrderId) references Orders(OrderId),
	Constraint fkOrderDetailsProductId foreign key (ProductId) references Products(ProductId),
);

/*	Billing -> BillingId, OrderId, BilledAmt, BilledDate, BillMethod
		BillingId is the primary key
		Billing.OrderId has a foreign key relationship with Orders.OrderId
*/
CREATE TABLE Billing(
	BillingId int Primary key,
	OrderId int,
	BilledAmt decimal(6,2),
	BilledDate DATETIME DEFAULT GETDATE(),
	BillMethod varchar(100),
	Constraint fkBillingOrderId foreign key (OrderId) references Orders(OrderId)
);

/*		Shipping -> ShippingId, OrderId, CareerCode, Tracking, Status
		ShippingId is the primary key
		Shipping.OrderId has a foreign key relationship with Orders.OrderId
*/
CREATE TABLE Shipping(
	ShippingId int Primary key,
	OrderId int,
	CareerCode varchar(100),
	Tracking varchar(100),
	ShippedDate DATETIME DEFAULT GETDATE(),
	Status varchar(100),
	Constraint fkShipping foreign key (OrderId) references Orders(OrderId)
);