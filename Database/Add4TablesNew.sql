
CREATE TABLE seller (
	seller_id INT IDENTITY (1, 1) PRIMARY KEY,
	seller_name VARCHAR(255) NOT NULL
);

CREATE TABLE district (
	district_id INT IDENTITY (1, 1) PRIMARY KEY,
	district_name  VARCHAR (255) UNIQUE NOT NULL,
	seller_id INT NOT NULL,
	FOREIGN KEY (seller_id) REFERENCES seller (seller_id)
);

CREATE TABLE store (
	store_id INT IDENTITY (1, 1) PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	district_id INT NOT NULL,
	FOREIGN KEY (district_id) REFERENCES district (district_id)
);

CREATE TABLE secondary_seller (
	seller_id INT NOT NULL,
	district_id INT NOT NULL,
	PRIMARY KEY (seller_id, district_id),
	FOREIGN KEY (seller_id) REFERENCES seller (seller_id),
	FOREIGN KEY (district_id) REFERENCES district (district_id)
);

--Having cascade on foreign keys cause cycles or multiple cascade paths.
GO
CREATE TRIGGER DELETE_seller 
ON seller 
INSTEAD OF DELETE
AS
	DELETE FROM district WHERE seller_id IN (SELECT seller_id FROM DELETED);
	DELETE FROM secondary_seller WHERE seller_id IN (SELECT seller_id FROM DELETED);
	DELETE FROM seller WHERE seller_id IN (SELECT seller_id FROM DELETED);

GO
CREATE TRIGGER DELETE_district
ON district
INSTEAD OF DELETE
AS
	DELETE FROM store WHERE district_id IN (SELECT district_id FROM DELETED);
	DELETE FROM secondary_seller WHERE district_id IN (SELECT district_id FROM DELETED);
	DELETE FROM district WHERE district_id IN (SELECT district_id FROM DELETED);


