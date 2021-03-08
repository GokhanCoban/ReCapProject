CREATE TABLE Cars (
    CarID int NOT NULL IDENTITY(1,1),
    BrandID int NOT NULL,
    ColorID int NOT NULL,
    ModelYear int NOT NULL,
    DailyPrice decimal(18,2) NOT NULL,
    Description nvarchar(100) NOT NULL,
    CONSTRAINT PK_CarID PRIMARY KEY (CarID),
    CONSTRAINT FK_CarColor FOREIGN KEY (ColorID)
    REFERENCES Colors(ColorID),
    CONSTRAINT FK_CarBrand FOREIGN KEY (BrandID)
    REFERENCES Brands(BrandID)

);

CREATE TABLE Brands(
   
   BrandID int NOT NULL IDENTITY(1,1),
   BrandName nvarchar(20) NOT NULL,
   CONSTRAINT PK_Brand PRIMARY KEY (BrandID),


);