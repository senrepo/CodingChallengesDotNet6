SELECT
    product_id,
    product_name,
    category_id,
    model_year,
    list_price
FROM
    production.products
Order by category_id

--find list of products whose price is more the average price of the category

select category_id, avg(list_price) from production.products 
group by category_id

SELECT
    product_id,
    product_name,
    category_id,
    model_year,
    list_price
FROM
    production.products A
where list_price <= (
	select avg(B.list_price) from production.products B
	where B.category_id = A.category_id
)
order by category_id, model_year