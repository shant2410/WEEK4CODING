-- Q7: Create Worker table
IF OBJECT_ID('Worker', 'U') IS NOT NULL
    DROP TABLE Worker;

CREATE TABLE Worker (
    WORKER_ID INT PRIMARY KEY,
    FIRST_NAME CHAR(25) NOT NULL,
    LAST_NAME CHAR(25),
    SALARY INT CHECK (SALARY BETWEEN 10000 AND 25000),
    JOINING_DATE DATETIME,
    DEPARTMENT CHAR(25) CHECK (DEPARTMENT IN ('HR','Sales','Accts','IT'))
);

-- Q8: Insert/Update Procedure
IF OBJECT_ID('InsertOrUpdateWorker', 'P') IS NOT NULL
    DROP PROCEDURE InsertOrUpdateWorker;
GO

CREATE PROCEDURE InsertOrUpdateWorker
    @WORKER_ID INT,
    @FIRST_NAME CHAR(25),
    @LAST_NAME CHAR(25),
    @SALARY INT,
    @JOINING_DATE DATETIME,
    @DEPARTMENT CHAR(25)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Worker WHERE WORKER_ID = @WORKER_ID)
    BEGIN
        UPDATE Worker
        SET FIRST_NAME = @FIRST_NAME,
            LAST_NAME = @LAST_NAME,
            SALARY = @SALARY,
            JOINING_DATE = @JOINING_DATE,
            DEPARTMENT = @DEPARTMENT
        WHERE WORKER_ID = @WORKER_ID;

        PRINT 'Record Updated';
    END
    ELSE
    BEGIN
        INSERT INTO Worker (WORKER_ID, FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT)
        VALUES (@WORKER_ID, @FIRST_NAME, @LAST_NAME, @SALARY, @JOINING_DATE, @DEPARTMENT);

        PRINT 'Record Added';
    END
END;
GO

-- Q9: Delete Procedure
IF OBJECT_ID('DeleteWorker', 'P') IS NOT NULL
    DROP PROCEDURE DeleteWorker;
GO

CREATE PROCEDURE DeleteWorker
    @WORKER_ID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Worker WHERE WORKER_ID = @WORKER_ID)
    BEGIN
        DELETE FROM Worker WHERE WORKER_ID = @WORKER_ID;
        PRINT 'Record Deleted';
    END
    ELSE
    BEGIN
        PRINT 'Record Not Found';
    END
END;
GO



-- Insert new worker
EXEC InsertOrUpdateWorker 1, 'John', 'Doe', 15000, '2025-08-11', 'HR';
EXEC InsertOrUpdateWorker 2, 'John1', 'Doe1', 16000, '2025-08-11', 'HR';

-- Update existing worker
EXEC InsertOrUpdateWorker 1, 'John', 'Smith', 18000, '2025-08-11', 'Sales';

-- Delete worker
EXEC DeleteWorker 1;

-- View table
SELECT * FROM Worker;
