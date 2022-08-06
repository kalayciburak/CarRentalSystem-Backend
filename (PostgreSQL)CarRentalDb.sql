CREATE DATABASE "CarRentalSystem";

DROP TABLE IF EXISTS "Cars";
DROP TABLE IF EXISTS "Colors";
DROP TABLE IF EXISTS "Brands";
DROP TABLE IF EXISTS "Users";
DROP TABLE IF EXISTS "Customers";
DROP TABLE IF EXISTS "Rentals";

CREATE TABLE "Cars"
(
    "CarId"       integer primary key generated always as identity,
    "BrandId"     INTEGER NOT NULL,
    "ColorId"     INTEGER NOT NULL,
    "ModelYear"   INTEGER NOT NULL,
    "DailyPrice"  INTEGER NOT NULL,
    "Description" TEXT    NOT NULL
);

CREATE TABLE "Colors"
(
    "ColorId"   integer primary key generated always as identity,
    "ColorName" TEXT NOT NULL,
    CONSTRAINT UQ_Color UNIQUE ("ColorName")
);


CREATE TABLE "Brands"
(
    "BrandId"   integer primary key generated always as identity,
    "BrandName" TEXT NOT NULL,
    CONSTRAINT UQ_Brand UNIQUE ("BrandName")
);

CREATE TABLE "Users"
(
    "UserId"    integer primary key generated always as identity,
    "FirstName" CHARACTER VARYING(35)  NOT NULL,
    "LastName"  CHARACTER VARYING(35)  NOT NULL,
    "Email"     CHARACTER VARYING(320) NOT NULL,
    "Password"  CHARACTER VARYING(25)  NOT NULL
);

CREATE TABLE "Customers"
(
    "CustomerId"  integer primary key generated always as identity,
    "UserId"      INTEGER               NOT NULL,
    "CompanyName" CHARACTER VARYING(35) NOT NULL
);

CREATE TABLE "Rentals"
(
    "RentalId"   integer primary key generated always as identity,
    "CarId"      INTEGER NOT NULL,
    "CustomerId" INTEGER NOT NULL,
    "RentDate"   DATE    NOT NULL,
    "ReturnDate" DATE
);

ALTER TABLE "Cars"
    ADD CONSTRAINT FK_Car_Brand FOREIGN KEY ("BrandId") REFERENCES "Brands" ("BrandId");
ALTER TABLE "Cars"
    ADD CONSTRAINT FK_Car_Color FOREIGN KEY ("ColorId") REFERENCES "Colors" ("ColorId");
ALTER TABLE "Customers"
    ADD CONSTRAINT FK_User_Customer FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId");
ALTER TABLE "Rentals"
    ADD CONSTRAINT FK_Rental_Car FOREIGN KEY ("CarId") REFERENCES "Cars" ("CarId");
ALTER TABLE "Rentals"
    ADD CONSTRAINT FK_Rental_Customer FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId");