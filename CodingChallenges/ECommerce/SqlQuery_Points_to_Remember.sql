

--Points to Remember


/*	Difference between DECIMAL and NUMERIC
		DECIMAL(6,2) - 1000.2 not strictly enforce the precision format
		NUMERIC(6,2) - strictly enforce the precision format
*/


/*	Can we use more than on Aggregate function in the join queries?
		Aggregate function used on the tables where it has one to many releationship
		If you are using Aggregate functions on two different tables which ahs one to many releationship, then it will produce incorect results
		As workaround, create a separate queries for each Aggregate function and the perform the join.
*/


/*
	To test whether a value is NULL or not, you always use the IS NULL operator.
	Below comparisions are not valid
		The results of the following comparisons are
			NULL = 0
			NULL <> 0
			NULL > 0
			NULL = NULL
*/


/*
	What are the joins in sql server?
		inner join
		left join
		right join
		full otuer join
		cross join
		self join - inner join only but joining the same tables
*/


/*
	What is difference between Primary Key and Unique key?
		Primary key
			Primary key doesn't allow nulls, so its perfect for record definition
			Primary key automatically the clustered index
			Only one primary key exists in the table
		Unique key
			Unique key allow only null value
			No index created automatically
			as many unique key exists in the table
*/