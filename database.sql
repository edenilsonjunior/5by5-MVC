USE DBCar;

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Car')
	drop table Car;
GO

if exists (SELECT * FROM dbo.SYSOBJECTS WHERE XTYPE = 'U' AND NAME = 'Insurance')
	drop table Insurance;
GO




CREATE TABLE Insurance(

    id INT IDENTITY(1,1),
    description VARCHAR(255),

    CONSTRAINT pkinsurance PRIMARY KEY (id)
);


CREATE TABLE Car(

    id INT IDENTITY(1, 1) NOT NULL,
    name VARCHAR(50),
    color VARCHAR(30),
    year INT,
    insurance_id INT,

    CONSTRAINT pkcar PRIMARY KEY (id),
    CONSTRAINT fkcar FOREIGN KEY (insurance_id) REFERENCES Insurance(id)
);

SELECT * FROM Car;
SELECT * FROM Insurance;

