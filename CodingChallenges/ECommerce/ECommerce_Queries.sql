USE Ecommerce;

select * from Products; 
select *  from  Customers;
Select * from Inventory;
Select * from Cart;
Select * from Orders;
Select * from OrderDetails;
Select * from Billing;
Select * from Shipping;


-- get the product inventory list
select p.ProductId, p.ProductName, p.Price, i.Qty from Products p 
inner join Inventory i on p.ProductId = i.ProductId

/* Get the customer order report consist of the following details
	CustomerId, CustomerName, OrderId, OrderStatus, OrderTotalAmount, Billed Total Amt, Shipping Status
*/

select top 1 *  from  Customers;
Select top 1 * from Orders;
Select top 1 * from OrderDetails;

-- Order table has one to many releationship with Order details table
select * from Customers c 
inner join Orders o on c.CustomerId = o.CustomerId
inner join OrderDetails od on od.OrderId = o.OrderId
inner join Shipping s on s.OrderId = o.OrderId

-- Order table has one to many releationship with Billing table
select * from Orders o
inner join Billing b on b.OrderId = o.OrderId

--since we have to use two aggregate function on different table, we need to use two separte queries

select * from (
	select c.CustomerId, c.CustomerName, o.OrderId, o.OrderStatus, s.Status as ShippingStatus, sum(UnitPrice * Quantity) TotalPrice from Customers c 
	inner join Orders o on c.CustomerId = o.CustomerId
	inner join OrderDetails od on od.OrderId = o.OrderId
	inner join Shipping s on s.OrderId = o.OrderId
	group by c.CustomerId, c.CustomerName, o.OrderId, o.OrderStatus, s.Status) A
	inner join
	(	
	select O.OrderId, sum(b.BilledAmt) BilledAmt from Orders o
	inner join Billing b on b.OrderId = o.OrderId
	group by O.OrderId) B 
	on A.OrderId = B.OrderId






