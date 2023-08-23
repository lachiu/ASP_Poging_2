INSERT INTO Locations (Name,UserId) VALUES ('Kast 1', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Kast 2', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Kast 3', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Kast 4', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Diepvries 1', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Diepvries 2', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Zolder kast 1', '{{UserId}}');
INSERT INTO Locations (Name,UserId) VALUES ('Keukenschuif 1', '{{UserId}}');

INSERT INTO VatPercentages (Percentage)
VALUES
(0),
(6),
(11),
(21);

INSERT INTO Products (Name,Description,Barcode)
VALUES
('Banaan','Een vserId}}),
(4,11.00,CURRENT_TIMESTAMP,{{UserId}}),
(5,5.56,CURRENT_TIMESTAMP,{{UserId}}),
(6,13.20,CURRENT_TIMESTAMP,{{UserId}}),
(7,11.49,CURRENT_TIMESTAMP,{{UserId}}),
(8,6.66,CURRENT_TIMESTAMP,{{UserId}}),
(9,7.89,CURRENT_TIMESTAMP,{{UserId}}),
(1,1.23,CURRENT_TIMESTAMP,{{UserId}}),
(2,44.44,CURRENT_TIMESTAMP,{{UserId}}),
(3,12.22,CURRENT_TIMESTAMP,{{UserId}});

INSERT INTO TicketsProducts (ProductId,Qty,TicketId,UnitPrice,VatPercentageId)
VALUES
(1,3,1,3.50,2),
(8,1,1,4.00,4),
(2,2,2,0.50,2);erse tros bananen.','vers1'),
('Appel','Een appel van de lokale boer, prijs per stuk.','vers2'),
('Blik Ice Tea 0.33cl','Lipton Ice Tea, prijs per blik, 0.33cl. Original Sparkling','blik1'),
('Pak koffie','500g','pak1'),
('Doosje Lipton Theezakjes','50 stukes','thee1'),
('Cola 1.5l','Wit product, Cola','cola'),
('Kopje','Wit porseleinen kopje','porseleinkopje'),
('HDMI 2.0b kabel 1.5m','Een HDMI kabel van 1.5m met HDCP in verpakking.','hdmi_kabel_150cm');

INSERT INTO Stocks (Qty,LocationId,ProductId)
VALUES
(2,1,1),
(11,8,2),
(5,3,3),
(6,4,4),
(2,6,5),
(3,7,6),
(1,2,7),
(8,1,8),
(13,1,5),
(1,3,6),
(3,4,7),
(4,5,1),
(6,6,2),
(7,7,3),
(1,8,4);

INSERT INTO Tickets (StoreId,Total,PurchaseDate,UserId)
VALUES
(1,12.50,CURRENT_TIMESTAMP,{{UserId}}),
(2,25.00,CURRENT_TIMESTAMP,{{UserId}}),
(3,23.99,CURRENT_TIMESTAMP,{{UserId}}),
(4,11.00,CURRENT_TIMESTAMP,{{UserId}}),
(5,5.56,CURRENT_TIMESTAMP,{{UserId}}),
(6,13.20,CURRENT_TIMESTAMP,{{UserId}}),
(7,11.49,CURRENT_TIMESTAMP,{{UserId}}),
(8,6.66,CURRENT_TIMESTAMP,{{UserId}}),
(9,7.89,CURRENT_TIMESTAMP,{{UserId}}),
(1,1.23,CURRENT_TIMESTAMP,{{UserId}}),
(2,44.44,CURRENT_TIMESTAMP,{{UserId}}),
(3,12.22,CURRENT_TIMESTAMP,{{UserId}});

INSERT INTO TicketsProducts (ProductId,Qty,TicketId,UnitPrice,VatPercentageId)
VALUES
(1,3,1,3.50,2),
(8,1,1,4.00,4),
(2,2,2,0.50,2);
