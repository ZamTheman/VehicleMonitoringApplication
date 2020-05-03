CREATE DATABASE vehicledb;

USE vehicledb;

CREATE TABLE company(
Id int,
Name char(50),
Street char(50),
PostalCode int,
City char(50),
PRIMARY KEY(Id)
) DEFAULT CHARACTER SET utf8 COLLATE utf8_swedish_ci;

INSERT INTO company
VALUES
(1, 'Kalles Grustransporter AB', 'Cementvägen 8', 11111, 'Södertälje'),
(2, 'Johans Bulk AB', 'Balkvägen 12', 22222, 'Stockholm'),
(3, 'Haralds Värdetransporter AB', 'Budgetvägen 1', 33333, 'Uppsala');

CREATE TABLE vehicle(
Vin char(50),
CompanyId int,
RegistrationNumber char(10),
LastCommunicated datetime,
PRIMARY KEY(Vin),
FOREIGN KEY(CompanyId) REFERENCES company(Id)
);

INSERT INTO vehicle
VALUES
('YS2R4X20005399401', 1, 'ABC123', NOW()),
('VLUR4X20009093588', 1, 'DEF456', NOW()),
('VLUR4X20009048066', 1, 'GHI789', NOW()),
('YS2R4X20005388011', 2, 'JKL012', NOW()),
('YS2R4X20005387949', 2, 'MNO345', NOW()),
('YS2R4X20005387765', 3, 'PQR678', NOW()),
('YS2R4X20005387055', 3, 'STU901', NOW());
