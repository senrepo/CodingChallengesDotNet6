
USE Ecommerce;

select top 1 * from Products; 
select top 1 *  from  Customers;
Select top 1* from Inventory;
Select top 1 * from Cart;
Select top 1 * from Orders;
Select top 1 * from OrderDetails;
Select top 1 * from Billing;
Select top 1 * from Shipping;

-- 1 to 1000
SET IDENTITY_INSERT Products ON;
INSERT INTO Products (ProductId, ProductName, Price) VALUES (1, 'TEST PRODUCT1', 20.25);
INSERT INTO Products (ProductId, ProductName, Price) VALUES (2, 'TEST PRODUCT2', 10.50);
SET IDENTITY_INSERT Products OFF;

--1 TO 1000
INSERT INTO Inventory (ProductId,Qty) VALUES (1,10)
INSERT INTO Inventory (ProductId,Qty) VALUES (2,5)

--1001 to 2000
SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (CustomerId, CustomerName, Address, City, State, Country, ZipCode) VALUES (1001, 'Raj Kumar', '500 COLD SPRING RD', 'HARTFORD', 'CT', 'USA', '06067');
SET IDENTITY_INSERT Customers OFF;

--2001 TO 3000
SET IDENTITY_INSERT Cart ON;
INSERT INTO Cart(CartId, CustomerId, ProductId, Qty) VALUES (2001, 1001, 1, 2);
INSERT INTO Cart(CartId, CustomerId, ProductId, Qty) VALUES (2001, 1001, 2, 1);
SET IDENTITY_INSERT Cart OFF;

--4001-5000
SET IDENTITY_INSERT Orders ON;
INSERT INTO Orders(OrderId, CustomerId, OrderStatus) VALUES (4001, 1001, 'CREATED');
SET IDENTITY_INSERT Orders OFF;

INSERT INTO OrderDetails(OrderId, ProductId, UnitPrice, Quantity, DiscountCode) VALUES (4001, 1, 20.5, 2, '');
INSERT INTO OrderDetails(OrderId, ProductId, UnitPrice, Quantity, DiscountCode) VALUES (4001, 2, 10.50, 1, '');

--5001 to 6000
SET IDENTITY_INSERT Billing ON;
INSERT INTO Billing(BillingId, OrderId, BillAmt, BillMethod) VALUES (5001, 4001, 31, 'CREDIT CARD');
update Billing set BillAmt = 40 where BillingId = 5001;
insert into Billing (BillingId, OrderId, BillAmt, BillMethod) VALUES (5002,4001,11.50, 'CHECK');
SET IDENTITY_INSERT Billing OFF;

--6001 to 7000
SET IDENTITY_INSERT Shipping ON;
INSERT INTO Shipping(ShippingId, OrderId, CareerCode, Tracking, STATUS) VALUES (6001, 4001, 'USPS', '345343', 'ENROUTE');
SET IDENTITY_INSERT Shipping OFF;