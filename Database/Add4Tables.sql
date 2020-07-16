

CREATE TABLE district (
	district_id INT IDENTITY (1, 1) PRIMARY KEY,
	district_name VARCHAR (255) NOT NULL
);

CREATE TABLE store (
	store_id INT IDENTITY (1, 1) PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	district_id INT NOT NULL,
	FOREIGN KEY (district_id) REFERENCES district (district_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE seller (
	seller_id INT IDENTITY (1, 1) PRIMARY KEY,
	seller_name VARCHAR(255) NOT NULL
);

CREATE TABLE selling_for (
	seller_id INT NOT NULL,
	district_id INT NOT NULL,
	responsible BIT NOT NULL,
	PRIMARY KEY (seller_id, district_id),
	FOREIGN KEY (seller_id) REFERENCES seller (seller_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (district_id) REFERENCES district (district_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE UNIQUE NONCLUSTERED INDEX unq_responsiblefor ON selling_for(district_id, responsible) WHERE (responsible = 1)
