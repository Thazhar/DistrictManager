use Centrica;

SET IDENTITY_INSERT district ON;

INSERT INTO district(district_id, district_name) VALUES(1, 'district_1')
INSERT INTO district(district_id, district_name) VALUES(2, 'district_2')
INSERT INTO district(district_id, district_name) VALUES(3, 'district_3')
INSERT INTO district(district_id, district_name) VALUES(4, 'district_4')

SET IDENTITY_INSERT district OFF;
SET IDENTITY_INSERT seller ON;

INSERT INTO seller(seller_id, seller_name) VALUES(1, 'seller_1')
INSERT INTO seller(seller_id, seller_name) VALUES(2, 'seller_2')
INSERT INTO seller(seller_id, seller_name) VALUES(3, 'seller_3')
INSERT INTO seller(seller_id, seller_name) VALUES(4, 'seller_4')

SET IDENTITY_INSERT seller OFF;
SET IDENTITY_INSERT store ON;

INSERT INTO store(store_id, district_id, store_name) VALUES(1, 1, 'store_1')
INSERT INTO store(store_id, district_id, store_name) VALUES(2, 2, 'store_2')
INSERT INTO store(store_id, district_id, store_name) VALUES(3, 3, 'store_3')
INSERT INTO store(store_id, district_id, store_name) VALUES(4, 4, 'store_4')

SET IDENTITY_INSERT store OFF;

INSERT INTO selling_for(seller_id, district_id, responsible) VALUES(1, 1, 1)
INSERT INTO selling_for(seller_id, district_id, responsible) VALUES(2, 2, 1)
INSERT INTO selling_for(seller_id, district_id, responsible) VALUES(2, 1, 0)
INSERT INTO selling_for(seller_id, district_id, responsible) VALUES(3, 1, 0)
INSERT INTO selling_for(seller_id, district_id, responsible) VALUES(4, 1, 0)
