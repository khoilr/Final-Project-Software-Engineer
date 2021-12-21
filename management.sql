Create database management
Go
Use management
--drop table import_details
--drop table delivery_details
--drop table products
--drop table import_receipts
--drop table delivery_receipts
--drop table accounts
--drop table customers

Create table customers(
	customer_id BigInt NOT NULL IDENTITY(1,1) primary key,
	full_name nvarchar(200) NOT NULL,
	[address] nvarchar(200) NOT NULL,
	phone nvarchar(200) NOT NULL
);

Create table accounts(
	account_id BigInt NOT NULL IDENTITY(1,1) primary key,
	full_name nvarchar(200) NOT NULL,
	username nvarchar(200) NOT NULL,
	[password] nvarchar(200) NOT NULL
);

Create table delivery_receipts(
	delivery_receipt_id BigInt NOT NULL IDENTITY(1,1) primary key,
	account_id BigInt NOT NULL foreign key references accounts(account_id),
	customer_id BigInt NOT NULL foreign key references customers(customer_id),
	date_created date NOT NULL,
	shipment_status nvarchar(200) NOT NULL,
	payment_status bit NOT NULL default 0,
);

Create table import_receipts(
	import_receipt_id BigInt NOT NULL IDENTITY(1,1) primary key,
	account_id BigInt NOT NULL foreign key references accounts(account_id),
	date_created date NOT NULL,	
);

Create table products(
	product_id BigInt NOT NULL IDENTITY(1,1) primary key,
	name nvarchar(200) NOT NULL,
	inventory int NOT NULL default 0,
);

Create table delivery_details(
	delivery_detail_id BigInt NOT NULL IDENTITY(1,1) primary key,
	delivery_receipt_id BigInt NOT NULL foreign key references delivery_receipts(delivery_receipt_id),
	product_id BigInt NOT NULL foreign key references products(product_id),
	quantity int NOT NULL,
	price money NOT NULL 
);

Create table import_details(
	import_detail_id BigInt NOT NULL IDENTITY(1,1) primary key,
	import_receipt_id BigInt NOT NULL foreign key references import_receipts(import_receipt_id),
	product_id BigInt NOT NULL foreign key references products(product_id),
	quantity int NOT NULL,
	price money NOT NULL
);

--Customers--
Insert into customers values ('Meryl Jeong','194 Jefferson StHickory','01926843109')
Insert into customers values ('Christian Eldon','412 Crescent Drive Canonsburg','07441163732')
Insert into customers values ('Carlyle Waylon','463 Clay Street Norman','07457992507')
Insert into customers values ('Vi Kerr','42 Gulf Drive Newnan','07561257119')
Insert into customers values ('Gojo Satoru','859 Valley View Avenue Smithtown','01423854198')

--Accounts--
Insert into accounts values ('Meryl Jeong','admin123','123')
Insert into accounts values ('Christian Eldon','admin456','456')
Insert into accounts values ('Carlyle Waylon','admin789','789')
Insert into accounts values ('Vi Kerr','admin135','135')
Insert into accounts values ('Gojo Satoru','admin246','246')

--Delivery_receipts--
Insert into delivery_receipts values ('1','1','2021-12-02','shipped','')
Insert into delivery_receipts values ('2','2','2021-12-13','shipped','')
Insert into delivery_receipts values ('3','3','2021-12-03','shipped','')
Insert into delivery_receipts values ('4','4','2021-12-14','shipped','')
Insert into delivery_receipts values ('5','5','2021-12-09','shipped','')

--Import_receipts--
Insert into import_receipts values ('1','2021-12-02')
Insert into import_receipts values ('2','2021-12-13')
Insert into import_receipts values ('3','2021-12-03')
Insert into import_receipts values ('4','2021-12-14')
Insert into import_receipts values ('5','2021-12-09')

--Products--
Insert into products values ('Daisy','')
Insert into products values ('Rose','')
Insert into products values ('Orchids','')
Insert into products values ('Ochna integerrima','')
Insert into products values ('Sakura','')

--Delivery_details--
Insert into delivery_details values ('1','1','20','32')
Insert into delivery_details values ('2','2','18','23')
Insert into delivery_details values ('3','3','32','16')
Insert into delivery_details values ('4','4','07','28')
Insert into delivery_details values ('5','5','13','40')

--Import_details--
Insert into import_details values ('1','1','30','22')
Insert into import_details values ('2','2','28','13')
Insert into import_details values ('3','3','42','06')
Insert into import_details values ('4','4','17','18')
Insert into import_details values ('5','5','23','30')

select * from customers
select * from accounts
select * from delivery_receipts
select * from import_receipts
select * from products
select * from delivery_details
select * from import_details