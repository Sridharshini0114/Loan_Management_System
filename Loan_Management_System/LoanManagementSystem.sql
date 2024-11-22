CREATE DATABASE LOAN_MANAGEMENT

CREATE TABLE Customer (
    customerID INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    emailAddress VARCHAR(255) UNIQUE NOT NULL,
    phoneNumber VARCHAR(15) NOT NULL,
    address TEXT,
    creditScore INT CHECK (creditScore BETWEEN 300 AND 850)
);
Select*from customer

-- Table for Loan
CREATE TABLE Loan (
    loanID INT IDENTITY(1,1) PRIMARY KEY,
    customerID INT NOT NULL,
    principalAmount DECIMAL(15, 2) NOT NULL,
    interestRate DECIMAL(5, 2) NOT NULL,
    loanTerm INT NOT NULL,
    loanType VARCHAR(20) CHECK (loanType IN ('CarLoan', 'HomeLoan')),
    loanStatus VARCHAR(20) CHECK (loanStatus IN ('Pending', 'Approved')),
    FOREIGN KEY (customerID) REFERENCES Customer(customerID) ON DELETE CASCADE
);
INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('John Doe', 'john.doe@example.com', '123-456-7890', '123 Elm Street, Springfield', 700);


INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('sridharshini', 'srivarshicse@example.com', '9342827054', 'namakkal', 750);

INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('sridharshini', 'srivarshicse@example.com', '9342827054', 'namakkal', 750);

INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('Thiya', 'Thiya@example.com', '9790530440', 'Salem', 600);

INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('Varshi', 'varshicse@example.com', '912356778', 'namakkal', 720);

INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('Vivega', 'vivega@gmail.com', '9442771409', 'Yercaud', 500);

INSERT INTO Customer (name, emailAddress, phoneNumber, address, creditScore)
VALUES ('Arshith', 'Arshith@gmail.com', '934532523', 'fairlands', 740);

select*from loan
