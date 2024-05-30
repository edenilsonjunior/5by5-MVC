USE DBCar;

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Car')
	drop table Car;
GO

CREATE TABLE Car(

    id INT IDENTITY(1, 1) NOT NULL,
    name VARCHAR(50),
    color VARCHAR(30),
    year INT,

    CONSTRAINT pkcar PRIMARY KEY (id)
);


SELECT * FROM Car;