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