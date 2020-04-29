CREATE DATABASE vehicledb;

USE vehicledb;

CREATE TABLE company(
Id int,
Name varchar(50),
Street varchar(50),
PostalCode int,
City varchar(50),
PRIMARY KEY(Id)
);

INSERT INTO company
VALUES
(1, 'Kalles Grustransporter AB', 'Cementvägen 8', 11111, 'Södertälje'),
(2, 'Johans Bulk AB', 'Balkvägen 12', 22222, 'Stockholm'),
(3, 'Haralds Värdetransporter AB', 'Budgetvägen 1', 33333, 'Uppsala');

CREATE TABLE vehicle(
Vin varchar(50),
CompanyId int,
RegistrationNumber varchar(10),
LastCommunicated datetime,
PRIMARY KEY(Vin),
FOREIGN KEY(CompanyId) REFERENCES company(Id)
);

INSERT INTO vehicle
VALUES
('YS2R4X20005399401', 1, 'ABC123'),
('VLUR4X20009093588', 1, 'DEF456'),
('VLUR4X20009048066', 1, 'GHI789'),
('YS2R4X20005388011', 2, 'JKL012'),
('YS2R4X20005387949', 2, 'MNO345'),
('YS2R4X20005387765', 3, 'PQR678'),
('YS2R4X20005387055', 3, 'STU901');
