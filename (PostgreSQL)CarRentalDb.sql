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
    "UserId"       integer primary key generated always as identity,
    "FirstName"    varchar(50) NOT NULL,
    "LastName"     varchar(50) NOT NULL,
    "Email"        varchar(50) NOT NULL,
    "PasswordHash" bytea       NOT NULL,
    "PasswordSalt" bytea       NOT NULL,
    "Status"       bool        NOT NULL
);

CREATE TABLE "OperationClaims"
(
    "Id"   integer primary key generated always as identity,
    "Name" varchar(250) NOT NULL
);

CREATE TABLE "UserOperationClaims"
(
    "Id"               integer primary key generated always as identity,
    "UserId"           integer NOT NULL,
    "OperationClaimId" integer NOT NULL
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

CREATE TABLE "CarImages"
(
    "CarImageId" integer primary key generated always as identity,
    "CarId"      INTEGER NOT NULL,
    "ImagePath"  TEXT,
    "DateAdded"  DATE    NOT NULL
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
ALTER TABLE "CarImages"
    ADD CONSTRAINT FK_Image_Car FOREIGN KEY ("CarId") REFERENCES "Cars" ("CarId");
ALTER TABLE "UserOperationClaims"
    ADD CONSTRAINT FK_UserOperationClaims_User FOREIGN KEY ("UserId") REFERENCES "Users" ("UserId");
ALTER TABLE "UserOperationClaims"
    ADD CONSTRAINT FK_UserOperationClaims_OperationClaim FOREIGN KEY ("OperationClaimId") REFERENCES "OperationClaims" ("Id");