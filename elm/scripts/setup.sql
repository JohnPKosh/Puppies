
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the module3assessment Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='module3assessment')
DROP DATABASE module3assessment;
GO

-- Create a new module3assessment Database
CREATE DATABASE module3assessment;
GO

-- Switch to the module3assessment Database
USE module3assessment
GO

BEGIN TRANSACTION;

create table puppies (
	id int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	weight INT,
	gender VARCHAR(50),
	paper_trained BIT
);
SET IDENTITY_INSERT puppies ON;
insert into puppies (id, name, weight, gender, paper_trained) values (1, 'Garçon', 8, 'Female', 0);
insert into puppies (id, name, weight, gender, paper_trained) values (2, 'Annotés', 15, 'Male', 1);
insert into puppies (id, name, weight, gender, paper_trained) values (3, 'Åke', 10, 'Male', 1);
insert into puppies (id, name, weight, gender, paper_trained) values (4, 'Börje', 9, 'Female', 1);
insert into puppies (id, name, weight, gender, paper_trained) values (5, 'Håkan', 14, 'Male', 0);
SET IDENTITY_INSERT puppies OFF;

COMMIT TRANSACTION;