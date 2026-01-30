USE master;
GO

IF DB_ID('SLEB_Billing_DB') IS NOT NULL
BEGIN
    ALTER DATABASE SLEB_Billing_DB 
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SLEB_Billing_DB;
    PRINT 'Database dropped successfully';
END

CREATE DATABASE SLEB_Billing_DB;
GO

USE SLEB_Billing_DB;
GO

CREATE TABLE CUSTOMER (
    Customer_Id_PK INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    NIC NVARCHAR(20) NOT NULL,
    Phone_No INT,
    Address NVARCHAR(250)
);
GO

CREATE TABLE CUSTOMER_ACCOUNT (
    Account_Id_pk INT IDENTITY PRIMARY KEY,
    Customer_Id_fk INT NOT NULL,
    AccountNumber INT NOT NULL UNIQUE,
    Account_Status NVARCHAR(30) NOT NULL,
    Username NVARCHAR(80) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FOREIGN KEY (Customer_Id_fk) REFERENCES CUSTOMER(Customer_Id_PK)
);
GO

CREATE TABLE ADMIN (
    admin_id_pk INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(80) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Status NVARCHAR(30) NOT NULL
);
GO

CREATE TABLE TARIFF_PLAN (
    TariffPlan_Id INT IDENTITY PRIMARY KEY,
    FixedCharge DECIMAL(18,2),
    RatePerUnit DECIMAL(18,4),
    Effective_From DATE,
    EffectiveTo DATE
);
GO

CREATE TABLE METER (
    Meter_Id_pk INT IDENTITY PRIMARY KEY,
    Meter_Number INT UNIQUE,
    Account_Id_fk INT NOT NULL,
    MeterStatus NVARCHAR(30),
    FOREIGN KEY (Account_Id_fk) REFERENCES CUSTOMER_ACCOUNT(Account_Id_pk)
);
GO

CREATE TABLE METER_READING (
    Reading_Id_pk INT IDENTITY PRIMARY KEY,
    Meter_Id_fk INT NOT NULL,
    ReadingMonth DATE,
    PreviousReadingValue DECIMAL(18,2),
    CurrentReadingValue DECIMAL(18,2),
    UnitsConsumed DECIMAL(18,2),
    FOREIGN KEY (Meter_Id_fk) REFERENCES METER(Meter_Id_pk)
);
GO

CREATE TABLE BILL (
    Bill_id_pk INT IDENTITY PRIMARY KEY,
    Account_Id_fk INT,
    Meter_Id_fk INT,
    Reading_Id_fk INT,
    TariffPlan_Id_fk INT,
    BillingMonth DATE,
    TotalBillAmount DECIMAL(18,2),
    PaidAmount DECIMAL(18,2),
    OutstandingAmount DECIMAL(18,2),
    DueDate DATE,
    BillStatus NVARCHAR(30),
    FOREIGN KEY (Account_Id_fk) REFERENCES CUSTOMER_ACCOUNT(Account_Id_pk),
    FOREIGN KEY (Meter_Id_fk) REFERENCES METER(Meter_Id_pk),
    FOREIGN KEY (Reading_Id_fk) REFERENCES METER_READING(Reading_Id_pk),
    FOREIGN KEY (TariffPlan_Id_fk) REFERENCES TARIFF_PLAN(TariffPlan_Id)
);
GO

CREATE TABLE PAYMENT (
    Payment_Id_pk INT IDENTITY PRIMARY KEY,
    Account_Id_fk INT,
    PaymentDate DATE,
    AmountPaid DECIMAL(18,2),
    PaymentStatus NVARCHAR(30),
    Bill_Id_fk INT,
    FOREIGN KEY (Account_Id_fk) REFERENCES CUSTOMER_ACCOUNT(Account_Id_pk),
    FOREIGN KEY (Bill_Id_fk) REFERENCES BILL(Bill_id_pk)
);
GO

CREATE TABLE NOTIFICATION (
    Notification_id_pk INT IDENTITY PRIMARY KEY,
    Account_id_fk INT,
    Bill_id_fk INT,
    Title NVARCHAR(150),
    Message NVARCHAR(500),
    FOREIGN KEY (Account_id_fk) REFERENCES CUSTOMER_ACCOUNT(Account_Id_pk),
    FOREIGN KEY (Bill_id_fk) REFERENCES BILL(Bill_id_pk)
);
GO

CREATE TABLE LOGIN (
    Login_id_Pk INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(80),
    Password NVARCHAR(255),
    Role NVARCHAR(30),
    Admin_Id_fk INT NULL,
    Account_Id_fk INT NULL,
    FOREIGN KEY (Admin_Id_fk) REFERENCES ADMIN(admin_id_pk),
    FOREIGN KEY (Account_Id_fk) REFERENCES CUSTOMER_ACCOUNT(Account_Id_pk)
);
GO

INSERT INTO CUSTOMER (Name, NIC, Phone_No, Address)
VALUES
('Kamal Perera', '901234567V', 771234567, 'Colombo'),
('Nimal Silva', '881234568V', 772345678, 'Kandy');

INSERT INTO CUSTOMER_ACCOUNT
(Customer_Id_fk, AccountNumber, Account_Status, Username, Password)
VALUES
(1, 10001, 'ACTIVE', 'kamal', '12345'),
(2, 10002, 'ACTIVE', 'nimal', '12345');

INSERT INTO ADMIN (Username, Password, Status)
VALUES
('admin', 'admin123', 'ACTIVE'),
('officer1', 'officer123', 'ACTIVE');

INSERT INTO TARIFF_PLAN
(FixedCharge, RatePerUnit, Effective_From, EffectiveTo)
VALUES
(500.00, 25.50, '2025-01-01', NULL),
(600.00, 30.00, '2025-06-01', NULL);

INSERT INTO METER
(Meter_Number, Account_Id_fk, MeterStatus)
VALUES
(90001, 1, 'ACTIVE'),
(90002, 2, 'ACTIVE');

INSERT INTO METER_READING
(Meter_Id_fk, ReadingMonth, PreviousReadingValue, CurrentReadingValue, UnitsConsumed)
VALUES
(1, '2025-01-01', 1200, 1300, 100),
(2, '2025-01-01', 800, 880, 80);

INSERT INTO BILL
(Account_Id_fk, Meter_Id_fk, Reading_Id_fk, TariffPlan_Id_fk,
 BillingMonth, TotalBillAmount, PaidAmount, OutstandingAmount, DueDate, BillStatus)
VALUES
(1, 1, 1, 1, '2025-01-01', 3050.00, 1000.00, 2050.00, '2025-01-15', 'PARTIAL'),
(2, 2, 2, 1, '2025-01-01', 2500.00, 2500.00, 0.00, '2025-01-15', 'PAID');

INSERT INTO PAYMENT
(Account_Id_fk, PaymentDate, AmountPaid, PaymentStatus, Bill_Id_fk)
VALUES
(1, '2025-01-10', 1000.00, 'PARTIAL', 1),
(2, '2025-01-08', 2500.00, 'PAID', 2);

INSERT INTO NOTIFICATION
(Account_id_fk, Bill_id_fk, Title, Message)
VALUES
(1, 1, 'Bill Due', 'Your electricity bill is due on 2025-01-15'),
(2, 2, 'Payment Successful', 'Your bill has been fully paid');

INSERT INTO LOGIN
(Username, Password, Role, Admin_Id_fk, Account_Id_fk)
VALUES
('admin', 'admin123', 'ADMIN', 1, NULL),
('kamal', '12345', 'CUSTOMER', NULL, 1),
('nimal', '12345', 'CUSTOMER', NULL, 2);

SELECT * FROM CUSTOMER;
SELECT * FROM CUSTOMER_ACCOUNT;
SELECT * FROM ADMIN;
SELECT * FROM TARIFF_PLAN;
SELECT * FROM METER;
SELECT * FROM METER_READING;
SELECT * FROM BILL;
SELECT * FROM PAYMENT;
SELECT * FROM NOTIFICATION;
SELECT * FROM LOGIN;

SELECT Username, [Password], Role, Account_Id_fk
FROM LOGIN;

INSERT INTO LOGIN (Username, [Password], Role, Admin_Id_fk, Account_Id_fk)
VALUES ('abe', 'abe123', 'CUSTOMER', NULL, 1);


INSERT INTO CUSTOMER (Name, NIC, Phone_No, Address)
VALUES ('Abe', '912345678V', 771234567, 'Colombo');

INSERT INTO CUSTOMER_ACCOUNT
(Customer_Id_fk, AccountNumber, Account_Status, Username, Password)
VALUES (1, 10003, 'ACTIVE', 'abe', 'abe123');

