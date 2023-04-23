
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

