use Kursach_DB

DROP TABLE IF EXISTS Ski, Sleigh, SkiPoles, Skates,  RepairProduct, RepairCompany, ProductBooking, DecommissionedProduct, 
ProductRent, Product, ProductGroup, ProductSubcategory, ProductCategory, Rent, Tenant, Gender,  Booking

GO
CREATE TABLE ProductCategory
(
Code INT PRIMARY KEY,
Name nvarchar(50) NOT NULL,
ProductCount INT,
)

INSERT INTO ProductCategory (Code, Name, ProductCount)
VALUES (3693, 'Спортивные товары', 62)

CREATE TABLE ProductSubcategory
(
ProductCategoryCode INT REFERENCES ProductCategory (Code),
Code INT PRIMARY KEY,
Name nvarchar(50) NOT NULL,
ProductCount INT,
)

INSERT INTO ProductSubcategory (ProductCategoryCode, Code, Name, ProductCount)
VALUES 
(3693, 10, 'Палки лыжные', 15),
(3693, 11, 'Коньки', 14),
(3693, 13, 'Сани спортивные', 11),
(3693, 16, 'Лыжи', 22)

CREATE TABLE ProductGroup
(
ProductSubcategoryCode INT REFERENCES ProductSubcategory (Code),
Code INT,
Name nvarchar(100) NOT NULL,
ProductCount INT,
PRIMARY KEY(Code, ProductSubcategoryCode)
)

INSERT INTO ProductGroup(ProductSubCategoryCode, Code, Name, ProductCount)
VALUES 
(10, 1, 'Палки лыжные алюминиевые', 6),
(10, 2, 'Палки лыжные стальные', 0),
(10, 3, 'Палки лыжные из стеклопластиков', 3),
(10, 4, 'Палки лыжные металлические гоночные спортивные', 3),
(10, 5, 'Палки горнолыжные спортивные', 3),
(11, 1, 'Коньки беговые', 0),
(11, 2, 'Коньки хоккейные', 5),
(11, 3, 'Коньки для фигурного катания', 4),
(11, 4, 'Коньки детские однополозные', 2),
(11, 5, 'Коньки детские двух- и трехполозные', 3),
(13, 1, 'Сани спортивные деревянные', 2),
(13, 2, 'Сани спортивные металлические', 7),
(13, 3, 'Сани спортивные прочие', 2),
(16, 1, 'Лыжи гоночные', 4),
(16, 2, 'Лыжи горные', 7),
(16, 3, 'Лыжи прыжковые', 0),
(16, 4, 'Лыжи спортивно-беговые', 6),
(16, 5, 'Лыжи туристические', 0),
(16, 6, 'Лыжи лесные', 0),
(16, 7, 'Лыжи детские', 5)


CREATE TABLE Product
(
Number INT PRIMARY KEY, -- 3693 10 1 01 - пример артикула
ProductSubcategoryCode INT,
Code INT,
Name nvarchar(50),
RentCostInHour MONEY NOT NULL,
IsProductInWarehouse BIT NOT NULL,
FOREIGN KEY (Code, ProductSubcategoryCode) REFERENCES ProductGroup(Code, ProductSubcategoryCode)
)

INSERT INTO Product(Number, ProductSubcategoryCode, Code, Name, RentCostInHour, IsProductInWarehouse)
VALUES
(369310101, 10, 1, 'Маяк', 150, 1),
(369310102, 10, 1, 'Маяк', 150, 0), --Пушкин
(369310103, 10, 1, 'Snowline', 200, 0),--Пушкин
(369310104, 10, 1, 'Snowline', 200, 1),
(369310105, 10, 1, 'Snowline', 200, 1),
(369310106, 10, 1, 'Spine', 180, 1),
(369310301, 10, 3, 'Tisa Sport Carbon', 250, 1),
(369310302, 10, 3, 'STC Sable', 100, 0), --Екатерина 8
(369310303, 10, 3, 'STC Sable', 100, 0),
(369310401, 10, 4, 'Peltonen X-RACE', 250, 0),--Яшин
(369310402, 10, 4, 'Peltonen X-RACE', 250, 1),
(369310403, 10, 4, 'Peltonen X-RACE', 250, 1),
(369310501, 10, 5, 'Head World Cup SG', 275, 1),
(369310502, 10, 5, 'Head World Cup SG', 275, 1),
(369310503, 10, 5, 'One Way RD 16 SL', 300, 0), -- списаны
(369310504, 10, 5, 'One Way RD 16 SL', 300, 1),
(369311201, 11, 2, 'ATEMI Drift 2.0', 150, 1),
(369311202, 11, 2, 'ATEMI Drift 2.0', 150, 1),
(369311203, 11, 2, 'ATEMI AHSK04 Escape', 200, 1),
(369311204, 11, 2, 'ATEMI AHSK04 Escape', 200, 0), -- аня 5
(369311205, 11, 2, 'ATEMI Ahsk02 Speed', 175, 1),
(369311301, 11, 3, 'ATEMI Basic', 165, 1),
(369311302, 11, 3, 'ATEMI Basic', 165, 0), -- списаны 
(369311303, 11, 3, 'Atemi Afskd01f', 160, 1),
(369311304, 11, 3, 'Atemi Afskd01f', 160, 1),
(369311401, 11, 4, 'TechTeam Kayot', 130, 1),
(369311402, 11, 4, 'ATEMI AKSK02D', 140, 1),
(369311501, 11, 5, 'Virtey', 160, 1),
(369311502, 11, 5, 'Virtey', 160, 0), --  забронирован 9 
(369311503, 11, 5, 'NORDWAY', 160, 0), -- Аня
(369313101, 13, 1, 'Морозко', 300, 1),
(369313102, 13, 1, 'Морозко', 300, 0),
(369313201, 13, 2, 'Беларусь', 180, 1),
(369313202, 13, 2, 'Беларусь', 180, 1),
(369313203, 13, 2, 'Тимка 5 Универсал', 160, 0), -- заброинрован 9
(369313204, 13, 2, 'Тимка 5 Универсал', 160, 1),
(369313205, 13, 2, 'Тимка 5 Универсал', 160, 1),
(369313206, 13, 2, 'Ветерок 6', 160, 1),
(369313207, 13, 2, 'Ветерок 6', 160, 0), -- Яшин
(369313301, 13, 3, 'KHW SR Swiss Bob', 130, 1),
(369313302, 13, 3, 'Gizmo riders STRATOS', 180, 0), -- Аня
(369316101, 16, 1, 'YOKO YXC Skating', 300, 1),
(369316102, 16, 1, 'YOKO YXC Skating', 300, 1),
(369316103, 16, 1, 'Peltonen Acadia Skate JR', 250, 0),
(369316104, 16, 1, 'BRADOS PRO SKATE AIR', 280, 0),
(369316201, 16, 2, 'Fischer RC One 72 MF', 400, 1),
(369316202, 16, 2, 'Fischer RC One 72 MF', 400, 1),
(369316203, 16, 2, 'Fischer RC One 72 MF', 400, 1), 
(369316204, 16, 2, 'Atomic Redster RX ERA', 420, 1),
(369316205, 16, 2, 'Atomic Redster RX ERA', 420, 0),
(369316206, 16, 2, 'Fischer RC4 WC RC Pro M.O-Plate', 425, 0),--Пушкин
(369316207, 16, 2, 'Fischer RC4 WC RC Pro M.O-Plate', 425, 0),--Екатерина 52
(369316401, 16, 4, 'BRADOS LS Sport STEP', 300, 0),--Пушкин
(369316402, 16, 4, 'BRADOS LS Sport STEP', 300, 0),
(369316403, 16, 4, 'BRADOS LS Sport STEP', 300, 0),
(369316404, 16, 4, 'BRADOS LS Sport STEP', 300, 0),
(369316405, 16, 4, 'WAX Innovation', 320, 1),
(369316406, 16, 4, 'MADSHUS 195 STEP', 330, 1),
(369316701, 16, 7, 'Nordway', 270, 1),
(369316702, 16, 7, 'Nordway', 270, 0),
(369316703, 16, 7, 'Nordway', 270, 0),
(369316704, 16, 7, 'Лыжики пыжики', 150, 1),
(369316705, 16, 7, 'Лыжики пыжики', 150, 0) -- Яшин

CREATE TABLE Gender
(
Type varchar(7) PRIMARY KEY
)

INSERT INTO Gender VALUES ('Мужской'), ('Женский')

CREATE TABLE Tenant
(
Id INT PRIMARY KEY IDENTITY,
FIO nvarchar(120) NOT NULL,
Age INT CHECK(Age >0 AND Age < 100),
Phone varchar(20) UNIQUE NOT NULL,
Gender varchar(7) REFERENCES Gender (Type)
)
	
INSERT INTO Tenant (FIO, Age, Phone, Gender)
VALUES 
('Александр Сергеевич Пушкин', 37, '89026515690', 'Мужской'),
('София Августа Фредерика Ангальт-Цербстская', 40, '89478901234', 'Женский'),
('Владимир Николаевич Яшин', 17, '89221515690', 'Мужской'),
('Иван Иванович Иванов', 28, '87777777777', 'Мужской'),
('Петр Петрович Петров', 31, '81234567789', 'Мужской'),
('Анна Николевна Исаева', 20, '89613265542', 'Женский'),
('Елизавета Юрьевна Лебедева', 20, '89127651234', 'Женский'),
('Михаил Андреевич Милорадович', 54, '89017689065', 'Мужской'),
('Феликс Эдмундович Дзержинский', 48, '8765123489', 'Мужской')

CREATE TABLE Booking
(
Id INT PRIMARY KEY IDENTITY,
TenantId INT FOREIGN KEY REFERENCES Tenant (Id),
DateEnd DATETIME NOT NULL
)

INSERT INTO Booking (TenantId, DateEnd)
VALUES
(9, '17.06.2023')

CREATE TABLE ProductBooking
(
BookingId INT FOREIGN KEY REFERENCES Booking (Id) ON DELETE CASCADE,
ProductNumber INT FOREIGN KEY REFERENCES Product (Number)
PRIMARY KEY(BookingId, ProductNumber)
)

INSERT INTO ProductBooking(BookingId, ProductNumber)
VALUES
(1, 369311502),
(1, 369313203)

CREATE TABLE Rent
(
Id INT PRIMARY KEY IDENTITY,
TenantId INT FOREIGN KEY REFERENCES Tenant (Id),
TotalRentCost MONEY NOT NULL,
DateStart DATETIME NOT NULL,
DateEnd DATETIME NOT NULL,
TotalDepositCost MONEY NOT NULL,
IsOver BIT
)

INSERT INTO Rent(TenantId, TotalRentCost, DateStart, DateEnd, TotalDepositCost, IsOver)
VALUES
(1, 3225, '04.04.2023 12:00', '04.04.2023 15:00', 3500, 0),
(2, 3675, '05.04.2023 10:00', '05.04.2023 17:00', 4000, 0),
(3, 1680, '05.04.2023 12:45', '05.04.2023 15:45', 2000, 0),
(6, 680, '01.05.2023 11:30', '01.05.2023 13:30', 1000, 0),
(6, 4800, '23.05.2023 10:30', '24.05.2023 10:30', 5000, 1),
(1, 800, '22.05.2023 10:00', '22.05.2023 12:00', 1000, 0)

CREATE TABLE ProductRent
(
RentId INT FOREIGN KEY REFERENCES Rent (Id) ON DELETE CASCADE,
ProductNumber INT FOREIGN KEY REFERENCES Product (Number),
PRIMARY KEY(RentId, ProductNumber)
)

INSERT INTO ProductRent(RentId,ProductNumber)
VALUES
(1,369310102),
(1,369310103),
(1,369316206),
(1,369316401), 
(2,369310302),
(2,369316207),
(3,369316705),
(3,369313207),
(3,369310401),
(4,369311503),
(4,369313302),
(5,369311204),
(6,369316203)

CREATE TABLE DecommissionedProduct
(
ProductNumber INT FOREIGN KEY REFERENCES Product (Number) PRIMARY KEY,
DecommissionedDate DATE NOT NULL,
Reason nvarchar(250) NOT NULL
)

INSERT INTO DecommissionedProduct (ProductNumber, DecommissionedDate, Reason)
VALUES 
(369310503, '05.05.2023', 'Потерялись'),
(369311302, '02.04.2023', 'Треснуло лезвие')

CREATE TABLE RepairCompany
(
Id INT PRIMARY KEY IDENTITY,
Name nvarchar(100) NOT NULL,
ProductSubcategoryCode INT REFERENCES ProductSubcategory (Code)
)

INSERT INTO RepairCompany (Name, ProductSubcategoryCode)
VALUES 
('Бережок', 10),
('Ремонт лыжных палок', 10),
('Острое лезвие', 11),
('Коньки', 11),
('Крутые коньки', 11),
('Санки', 13),
('Большая лыжа', 16),
('Ремонт лыж', 16)

CREATE TABLE RepairProduct
(
RepairCompanyId INT FOREIGN KEY REFERENCES RepairCompany (Id),
ProductNumber INT FOREIGN KEY REFERENCES Product (Number),
Cost MONEY NOT NULL,
DateStart DATE NOT NULL,
DateEnd DATE NOT NULL, 
IsOver BIT
PRIMARY KEY(RepairCompanyId, ProductNumber)
)

INSERT INTO RepairProduct (RepairCompanyId, ProductNumber, Cost, DateStart, DateEnd, IsOver)
VALUES 
(1, 369310101, 400, '13.04.2023', '24.04.2023', 1)

CREATE TABLE SkiPoles
(
ProductNumber INT FOREIGN KEY REFERENCES  Product (Number) ON DELETE CASCADE PRIMARY KEY,
ShaftMaterial nvarchar(50) NOT NULL,
HandleMaterial nvarchar(50) NOT NULL,
SkiPolesLength TINYINT NOT NULL  
)

INSERT INTO SkiPoles (ProductNumber, ShaftMaterial, HandleMaterial,SkiPolesLength)
VALUES
(369310101, 'Алюминий', 'Пластик', 150),
(369310102, 'Алюминий', 'Пластик', 170),
(369310103, 'Алюминий', 'Пластик', 165),
(369310104, 'Алюминий', 'Пластик', 145),
(369310105, 'Алюминий', 'Пластик', 175),
(369310106, 'Алюминий', 'Пластик', 140),
(369310301, 'Стеклопластик', 'Пробка', 150),
(369310302, 'Стеклопластик', 'Пластик', 150),
(369310303, 'Стеклопластик', 'Пластик', 140),
(369310401, 'Металлические', 'Пластик', 160),
(369310402, 'Металлические', 'Пластик', 160),
(369310403, 'Металлические', 'Пластик', 170),
(369310501, 'Алюминий', 'Резина', 160),
(369310502, 'Алюминий', 'Резина', 165),
(369310503, 'Алюминий', 'Карбон', 160),
(369310504, 'Алюминий', 'Карбон', 160)

CREATE TABLE Skates
(
ProductNumber INT FOREIGN KEY REFERENCES Product (Number) ON DELETE CASCADE PRIMARY KEY,
BladeSteel nvarchar(50) NOT NULL,
Fixation nvarchar(50) NOT NULL,
Size TINYINT NOT NULL
)

INSERT INTO Skates (ProductNumber, BladeSteel, Fixation, Size)
VALUES
(369311201, 'Нержавеющая', 'Шнурки', 41),
(369311202, 'Нержавеющая', 'Шнурки', 42),
(369311203, 'Высокоуглеродистая', 'Шнурки', 40),
(369311204, 'Высокоуглеродистая', 'Шнурки', 42),
(369311205, 'Высокоуглеродистая', 'Шнурки', 38),
(369311301, 'Нержавеющая', 'Шнурки', 37),
(369311302, 'Нержавеющая', 'Шнурки', 38),
(369311303, 'Нержавеющая', 'Шнурки', 39),
(369311304, 'Нержавеющая', 'Шнурки', 40),
(369311401, 'Нержавеющая', 'Липучки', 36),
(369311402, 'Нержавеющая', 'Бакля', 35),
(369311501, 'Нержавеющая', 'Шнурки', 35),
(369311502, 'Нержавеющая', 'Шнурки', 35),
(369311503, 'Нержавеющая', 'Клипса', 37)

CREATE TABLE Sleigh
(
ProductNumber INT FOREIGN KEY REFERENCES Product (Number) ON DELETE CASCADE PRIMARY KEY,
Construction nvarchar(50) NOT NULL,
RunnersType nvarchar(50) NOT NULL,
MaxLoad TINYINT NOT NULL  
)

INSERT INTO Sleigh (ProductNumber, Construction, RunnersType, MaxLoad)
VALUES
(369313101, 'Складная', 'Плоские', 70),
(369313102, 'Складная', 'Плоские', 70),
(369313201, 'Складная', 'Плоские', 70),
(369313202, 'Складная', 'Плоские', 70),
(369313203, 'Складная', 'Трубчатые', 25),
(369313204, 'Складная', 'Трубчатые', 25),
(369313205, 'Складная', 'Трубчатые', 25),
(369313206, 'Цельная', 'Плоские', 30),
(369313207, 'Цельная', 'Плоские', 30),
(369313301, 'Цельная', 'Плоские', 95),
(369313302, 'Цельная', '-', 100)

CREATE TABLE Ski
(
ProductNumber INT FOREIGN KEY REFERENCES Product (Number) ON DELETE CASCADE PRIMARY KEY,
RidingStyle nvarchar(50) NOT NULL,
SkiLength INT NOT NULL  
)

INSERT INTO Ski(ProductNumber, RidingStyle, SkiLength)
VALUES
(369316101, 'Коньковый', 194),
(369316102, 'Коньковый', 184),
(369316103, 'Коньковый', 167),
(369316104, 'Коньковый', 193),
(369316201, 'Горные', 170),
(369316202, 'Горные', 180),
(369316203, 'Горные', 190),
(369316204, 'Горные', 140),
(369316205, 'Горные', 156),
(369316206, 'Горные', 170),
(369316207, 'Горные', 175),
(369316401, 'Классический', 170),
(369316402, 'Классический', 180),
(369316403, 'Классический', 180),
(369316404, 'Классический', 175),
(369316405, 'Классический', 195),
(369316406, 'Классический', 160),
(369316701, 'Классический', 165),
(369316702, 'Классический', 160),
(369316703, 'Классический', 130),
(369316704, 'Классический', 140)
