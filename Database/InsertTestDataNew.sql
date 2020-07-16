use Centrica;

SET IDENTITY_INSERT seller ON;

INSERT INTO seller(seller_id, seller_name) VALUES(1, 'seller_1')
INSERT INTO seller(seller_id, seller_name) VALUES(2, 'seller_2')
INSERT INTO seller(seller_id, seller_name) VALUES(3, 'seller_3')
INSERT INTO seller(seller_id, seller_name) VALUES(4, 'seller_4')

SET IDENTITY_INSERT seller OFF;
SET IDENTITY_INSERT district ON;

INSERT INTO district(district_id, district_name, seller_id) VALUES(1, 'district_1', 1)
INSERT INTO district(district_id, district_name, seller_id) VALUES(2, 'district_2', 2)
INSERT INTO district(district_id, district_name, seller_id) VALUES(3, 'district_3', 2)
INSERT INTO district(district_id, district_name, seller_id) VALUES(4, 'district_4' ,3)

SET IDENTITY_INSERT district OFF;
SET IDENTITY_INSERT store ON;

INSERT INTO store(store_id, district_id, store_name) VALUES(1, 1, 'store_1')
INSERT INTO store(store_id, district_id, store_name) VALUES(2, 2, 'store_2')
INSERT INTO store(store_id, district_id, store_name) VALUES(3, 3, 'store_3')
INSERT INTO store(store_id, district_id, store_name) VALUES(4, 4, 'store_4')

SET IDENTITY_INSERT store OFF;

INSERT INTO secondary_seller(seller_id, district_id) VALUES(1, 2)
INSERT INTO secondary_seller(seller_id, district_id) VALUES(3, 3)
INSERT INTO secondary_seller(seller_id, district_id) VALUES(4, 1)
INSERT INTO secondary_seller(seller_id, district_id) VALUES(4, 3)
