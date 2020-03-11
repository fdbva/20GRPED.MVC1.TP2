CREATE TABLE CalculatorHistory(
	Id INT IDENTITY(0,1) PRIMARY KEY,
	Operator VARCHAR(1),
	LeftNumber DECIMAL,
	RightNumber DECIMAL,
	Result VARCHAR(100)
);

SELECT * FROM CalculatorHistory;

INSERT INTO CalculatorHistory
	(Operator, LeftNumber, RightNumber, Result)
	VALUES
	('+', 1, 2, '1 + 2 = 3');

DROP TABLE CalculatorHistory;

ALTER TABLE CalculatorHistory ADD Hora DATETIME;
UPDATE CalculatorHistory SET Hora = CURRENT_TIMESTAMP;
ALTER TABLE CalculatorHistory ALTER COLUMN Hora DATETIME NOT NULL;

SELECT Id as Id, Operator as Operator, LeftNumber as 'Left', RightNumber as 'Right', Result as Result FROM CalculatorHistory ORDER BY Hora DESC