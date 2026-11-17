# SQL notes

База: `PracticeDB`. Создание и тестовые данные — `init.sql`.

Результаты ниже указаны как ожидаемые по исходным данным. Фактический запуск в SSMS ещё не проверен.

## Задание 01 — Создание базы и таблиц

### SQL

```sql
-- Таблицы создаёт database/init.sql.
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'dbo'
  AND TABLE_NAME IN ('Departments', 'Employees', 'Projects', 'EmployeeProjects')
ORDER BY TABLE_NAME;
```

### Результат

После выполнения `init.sql` должны существовать 4 таблицы. (ожидаемый, проверить в SSMS).

### Вывод

Создаются таблицы и внешние ключи, включая связь руководителя с сотрудником.

## Задание 02 — Заполнение таблиц

### SQL

```sql
-- INSERT в четыре таблицы находится в init.sql.
SELECT (SELECT COUNT(*) FROM Departments) AS DepartmentsCount,
       (SELECT COUNT(*) FROM Employees) AS EmployeesCount,
       (SELECT COUNT(*) FROM Projects) AS ProjectsCount,
       (SELECT COUNT(*) FROM EmployeeProjects) AS AssignmentsCount;
```

### Результат

4 отдела, 10 сотрудников, 5 проектов и 14 назначений. (ожидаемый, проверить в SSMS).

### Вывод

Данные добавлены через `INSERT INTO ... VALUES` в `init.sql`.

## Задание 03 — SELECT и WHERE

### SQL

```sql
SELECT EmployeeName, Salary FROM Employees WHERE Salary > 50000;
SELECT EmployeeName, HireDate FROM Employees WHERE YEAR(HireDate) = 2023;
SELECT EmployeeName FROM Employees WHERE EmployeeName LIKE N'А%';
SELECT EmployeeName FROM Employees WHERE DepartmentId = 2;
SELECT EmployeeName, Salary FROM Employees WHERE Salary BETWEEN 40000 AND 60000;
```

### Результат

Ожидается соответственно 7, 2, 2, 3 и 6 строк. (ожидаемый, проверить в SSMS).

### Вывод

Проверены разные условия WHERE.

## Задание 04 — ORDER BY и TOP

### SQL

```sql
SELECT TOP (3) EmployeeName, Salary
FROM Employees ORDER BY Salary DESC;

SELECT TOP (5) EmployeeName, HireDate
FROM Employees ORDER BY HireDate;

SELECT EmployeeName, DepartmentId, Salary
FROM Employees ORDER BY DepartmentId, Salary DESC;
```

### Результат

По зарплате первые: Алексей Лебедев (90000), Пётр Сидоров (72000), Анна Иванова (65000). (ожидаемый, проверить в SSMS).

### Вывод

TOP ограничивает количество строк, ORDER BY меняет порядок.

## Задание 05 — Агрегатные функции

### SQL

```sql
SELECT COUNT(*) AS EmployeesCount,
       SUM(Salary) AS TotalSalary,
       ROUND(AVG(Salary), 2) AS AverageSalary,
       MIN(Salary) AS MinimumSalary,
       MAX(Salary) AS MaximumSalary,
       SUM(CASE WHEN Salary > 50000 THEN 1 ELSE 0 END) AS Over50000
FROM Employees;
```

### Результат

10 сотрудников; сумма 589000; средняя 58900; минимум 43000; максимум 90000; зарплата выше 50000 у 7. (ожидаемый, проверить в SSMS).

### Вывод

COUNT, SUM, AVG, MIN и MAX дают общую статистику.

## Задание 06 — GROUP BY по отделам

### SQL

```sql
SELECT DepartmentId, COUNT(*) AS EmployeesCount,
       ROUND(AVG(Salary), 2) AS AverageSalary,
       SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC;
```

### Результат

Отделы по средней зарплате: 4 (90000), 1 (60000), 2 (57000), 3 (44000). (ожидаемый, проверить в SSMS).

### Вывод

GROUP BY собирает сотрудников каждого отдела в одну группу.

## Задание 07 — GROUP BY и HAVING

### SQL

```sql
SELECT DepartmentId, COUNT(*) AS EmployeesCount
FROM Employees GROUP BY DepartmentId HAVING COUNT(*) > 2;

SELECT DepartmentId, AVG(Salary) AS AverageSalary
FROM Employees GROUP BY DepartmentId HAVING AVG(Salary) > 55000;

SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees GROUP BY DepartmentId HAVING SUM(Salary) > 150000;
```

### Результат

Больше двух сотрудников: отделы 1 и 2; средняя выше 55000: 1, 2, 4; сумма выше 150000: 1 и 2. (ожидаемый, проверить в SSMS).

### Вывод

HAVING проверяет агрегаты после группировки.

## Задание 08 — INNER JOIN сотрудников и отделов

### SQL

```sql
SELECT e.EmployeeName, d.DepartmentName, e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName, e.Salary DESC;
```

### Результат

Ожидается 10 сотрудников с названиями отделов. (ожидаемый, проверить в SSMS).

### Вывод

INNER JOIN выводит связанные записи двух таблиц.

## Задание 09 — LEFT JOIN без проектов

### SQL

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
WHERE ep.EmployeeId IS NULL;
```

### Результат

Наталья Соколова (EmployeeId = 9). (ожидаемый, проверить в SSMS).

### Вывод

LEFT JOIN позволяет найти сотрудника без назначения на проект.

## Задание 10 — Четыре таблицы через JOIN

### SQL

```sql
SELECT e.EmployeeName, d.DepartmentName, p.ProjectName, ep.Hours
FROM Employees e
INNER JOIN Departments d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects p ON p.ProjectId = ep.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;
```

### Результат

14 строк назначений с именем, отделом, проектом и часами. (ожидаемый, проверить в SSMS).

### Вывод

Соединены четыре таблицы по внешним ключам.

## Задание 11 — Self-join руководителей

### SQL

```sql
SELECT e.EmployeeName, m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON m.EmployeeId = e.ManagerId
ORDER BY e.EmployeeId;
```

### Результат

У Марии руководитель Пётр, у Ивана — Анна, у Дмитрия — Ольга, у Натальи — Алексей. Остальные NULL. (ожидаемый, проверить в SSMS).

### Вывод

Таблица Employees соединена сама с собой.

## Задание 12 — Подзапросы в WHERE

### SQL

```sql
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
```

### Результат

Выше средней зарплаты 58900 — 4 человека. Максимальная зарплата у Алексея Лебедева (90000). (ожидаемый, проверить в SSMS).

### Вывод

Подзапрос вычисляет значение для сравнения в WHERE.

## Задание 13 — Скалярный подзапрос

### SQL

```sql
SELECT e.EmployeeName, e.DepartmentId, e.Salary,
       (SELECT AVG(x.Salary) FROM Employees x
        WHERE x.DepartmentId = e.DepartmentId) AS DepartmentAverage,
       ROUND(e.Salary - (SELECT AVG(x.Salary) FROM Employees x
                         WHERE x.DepartmentId = e.DepartmentId), 2) AS Difference
FROM Employees e
ORDER BY e.DepartmentId, e.EmployeeId;
```

### Результат

По 1 строке на каждого из 10 сотрудников; разница с зарплатой его отдела. (ожидаемый, проверить в SSMS).

### Вывод

Скалярный подзапрос считает среднее отдельно для каждого отдела.

## Задание 14 — EXISTS и NOT EXISTS

### SQL

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE EXISTS (
    SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId
);

SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId
);
```

### Результат

С проектами 9 сотрудников; без проектов — Наталья Соколова. (ожидаемый, проверить в SSMS).

### Вывод

EXISTS проверяет наличие связанных строк без JOIN.

## Задание 15 — UNION и UNION ALL

### SQL

```sql
SELECT EmployeeId, EmployeeName FROM Employees WHERE Salary > 60000
UNION
SELECT EmployeeId, EmployeeName FROM Employees WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

SELECT EmployeeId, EmployeeName FROM Employees WHERE Salary > 60000
UNION ALL
SELECT EmployeeId, EmployeeName FROM Employees WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;
```

### Результат

UNION — 6 уникальных сотрудников; UNION ALL — 10 строк с повторами. (ожидаемый, проверить в SSMS).

### Вывод

UNION убирает дубликаты, UNION ALL оставляет их.

## Задание 16 — UPDATE зарплат и даты

### SQL

```sql
BEGIN TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE DepartmentId = 1;
UPDATE Employees SET Salary = ROUND(Salary * 1.10, 2) WHERE DepartmentId = 1;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE DepartmentId = 1;

SELECT EmployeeId, Salary FROM Employees WHERE HireDate < '2022-01-01';
UPDATE Employees SET Salary = Salary + 5000 WHERE HireDate < '2022-01-01';
SELECT EmployeeId, Salary FROM Employees WHERE HireDate < '2022-01-01';

SELECT EmployeeId, HireDate FROM Employees WHERE EmployeeId = 4;
UPDATE Employees SET HireDate = DATEADD(DAY, 1, HireDate) WHERE EmployeeId = 4;
SELECT EmployeeId, HireDate FROM Employees WHERE EmployeeId = 4;

ROLLBACK TRANSACTION;
```

### Результат

Внутри транзакции меняются только выбранные строки; ROLLBACK возвращает исходные данные. (фактический запуск не проверен).

### Вывод

UPDATE с WHERE меняет нужные записи; откат оставляет базу неизменной.

## Задание 17 — DELETE и ограничения FK

### SQL

```sql
BEGIN TRANSACTION;

SELECT COUNT(*) AS ZeroHoursBefore FROM EmployeeProjects WHERE Hours = 0;
DELETE FROM EmployeeProjects WHERE Hours = 0;
SELECT COUNT(*) AS ZeroHoursAfter FROM EmployeeProjects WHERE Hours = 0;

SELECT COUNT(*) AS AssignmentsBefore FROM EmployeeProjects;
DELETE FROM EmployeeProjects WHERE EmployeeId = 8;
SELECT COUNT(*) AS AssignmentsAfter FROM EmployeeProjects;

SELECT COUNT(*) AS EmployeesBefore FROM Employees;
DELETE FROM Employees WHERE EmployeeId = 8;
SELECT COUNT(*) AS EmployeesAfter FROM Employees;

SELECT * INTO #TempEmployees FROM Employees;
DELETE FROM #TempEmployees;
SELECT COUNT(*) AS TempCountAfter FROM #TempEmployees;

ROLLBACK TRANSACTION;
```

### Результат

Исходно нулевых часов нет. В транзакции назначений становится 13, сотрудников 9, тестовая таблица пустая; затем откат. (фактический запуск не проверен).

### Вывод

Сначала удаляем связанные назначения, затем сотрудника. DELETE без WHERE проверен на копии.

## Задание 18 — Транзакции

### SQL

```sql
DECLARE @OldSalary DECIMAL(10,2);
SELECT @OldSalary = Salary FROM Employees WHERE EmployeeId = 1;
SELECT EmployeeId, Salary AS BeforeChange FROM Employees WHERE EmployeeId = 1;

BEGIN TRANSACTION;
UPDATE Employees SET Salary = Salary + 1000 WHERE EmployeeId = 1;
SELECT EmployeeId, Salary AS InsideRollback FROM Employees WHERE EmployeeId = 1;
ROLLBACK TRANSACTION;
SELECT EmployeeId, Salary AS AfterRollback FROM Employees WHERE EmployeeId = 1;

BEGIN TRANSACTION;
UPDATE Employees SET Salary = Salary + 1000 WHERE EmployeeId = 1;
SELECT EmployeeId, Salary AS InsideCommit FROM Employees WHERE EmployeeId = 1;
COMMIT TRANSACTION;
SELECT EmployeeId, Salary AS AfterCommit FROM Employees WHERE EmployeeId = 1;

UPDATE Employees SET Salary = @OldSalary WHERE EmployeeId = 1;
SELECT EmployeeId, Salary AS Restored FROM Employees WHERE EmployeeId = 1;
```

### Результат

65000 → 66000 → ROLLBACK до 65000; после COMMIT 66000; в конце возвращено 65000 для других заданий. (фактический запуск не проверен).

### Вывод

ROLLBACK отменяет изменения, COMMIT сохраняет их.

## Задание 19 — Представление VIEW

### SQL

```sql
IF OBJECT_ID(N'dbo.vw_EmployeeDetails', N'V') IS NOT NULL
    DROP VIEW dbo.vw_EmployeeDetails;
GO
CREATE VIEW dbo.vw_EmployeeDetails AS
SELECT e.EmployeeName, d.DepartmentName, p.ProjectName, ep.Hours
FROM Employees e
INNER JOIN Departments d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects p ON p.ProjectId = ep.ProjectId;
GO
SELECT * FROM dbo.vw_EmployeeDetails;
GO
DROP VIEW dbo.vw_EmployeeDetails;
GO
```

### Результат

Представление содержит 14 строк назначений и затем удаляется. (фактический запуск не проверен).

### Вывод

VIEW сохраняет SQL-запрос для повторного использования.

## Задание 20 — Индексы и планы

### SQL

```sql
SET STATISTICS IO ON;
SELECT EmployeeName, Salary FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Employees_DepartmentId' AND object_id = OBJECT_ID('dbo.Employees'))
    CREATE INDEX IX_Employees_DepartmentId ON Employees(DepartmentId);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Employees_Salary' AND object_id = OBJECT_ID('dbo.Employees'))
    CREATE INDEX IX_Employees_Salary ON Employees(Salary);

SELECT EmployeeName, Salary FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;
SET STATISTICS IO OFF;

SELECT name FROM sys.indexes
WHERE object_id = OBJECT_ID('dbo.Employees')
  AND name IN ('IX_Employees_DepartmentId', 'IX_Employees_Salary');
```

### Результат

Вторая выборка возвращает те же 3 строки. Два индекса создаются; план и logical reads нужно снять в SSMS с включённым фактическим планом (Ctrl+M). На маленькой таблице оптимизатор может выбрать скан. (фактический запуск не проверен).

### Вывод

Индексы могут ускорить поиск, но выбор плана зависит от размера таблицы.

## Задание 21 — Хранимые процедуры

### SQL

```sql
CREATE OR ALTER PROCEDURE dbo.sp_GetEmployeesByDepartment
    @DeptId INT
AS
BEGIN
    SELECT EmployeeId, EmployeeName, Salary
    FROM Employees WHERE DepartmentId = @DeptId;
END;
GO
EXEC dbo.sp_GetEmployeesByDepartment @DeptId = 1;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetAverageSalaryByDepartment
    @DeptId INT,
    @AvgSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @AvgSalary = AVG(Salary)
    FROM Employees WHERE DepartmentId = @DeptId;
END;
GO
DECLARE @Average DECIMAL(10,2);
EXEC dbo.sp_GetAverageSalaryByDepartment @DeptId = 1, @AvgSalary = @Average OUTPUT;
SELECT @Average AS AverageSalary;
GO
```

### Результат

Первая процедура выводит 4 сотрудников отдела 1, вторая возвращает среднюю зарплату 60000. (ожидаемый, проверить в SSMS).

### Вывод

Процедуры принимают входной и выходной параметры.

## Задание 22 — Скалярная и табличная функции

### SQL

```sql
CREATE OR ALTER FUNCTION dbo.fn_GetAnnualSalary(@MonthlySalary DECIMAL(10,2))
RETURNS DECIMAL(12,2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO
CREATE OR ALTER FUNCTION dbo.fn_GetEmployeesBySalaryRange(
    @Min DECIMAL(10,2), @Max DECIMAL(10,2))
RETURNS TABLE
AS
RETURN
(
    SELECT EmployeeName, Salary FROM Employees
    WHERE Salary BETWEEN @Min AND @Max
);
GO
SELECT EmployeeName, dbo.fn_GetAnnualSalary(Salary) AS AnnualSalary FROM Employees;
SELECT * FROM dbo.fn_GetEmployeesBySalaryRange(50000, 70000);
GO
```

### Результат

Годовая зарплата равна месячной × 12; табличная функция выводит сотрудников в диапазоне 50000–70000. (ожидаемый, проверить в SSMS).

### Вывод

Скалярную функцию используют в SELECT, табличную — в FROM.

## Задание 23 — ROW_NUMBER, RANK и DENSE_RANK

### SQL

```sql
BEGIN TRANSACTION;
-- Временно сделаем зарплату Петра равной зарплате Анны, чтобы показать одинаковый ранг.
UPDATE Employees SET Salary = 65000 WHERE EmployeeId = 2;

SELECT EmployeeName, DepartmentId, Salary,
       ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNumber,
       RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank,
       DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS DenseSalaryRank
FROM Employees
ORDER BY DepartmentId, Salary DESC;

ROLLBACK TRANSACTION;
```

### Результат

Два сотрудника отдела 1 получают одинаковый RANK=1; следующий получает RANK=3, но DENSE_RANK=2. Изменение отменяется. (ожидаемый, проверить в SSMS).

### Вывод

DENSE_RANK не пропускает номера при одинаковых значениях.

## Задание 24 — Оконные агрегаты

### SQL

```sql
SELECT EmployeeName, DepartmentId, Salary,
       SUM(Salary) OVER (PARTITION BY DepartmentId) AS DepartmentTotal,
       ROUND(AVG(Salary) OVER (PARTITION BY DepartmentId), 2) AS DepartmentAverage,
       ROUND(Salary - AVG(Salary) OVER (PARTITION BY DepartmentId), 2) AS Difference
FROM Employees
ORDER BY DepartmentId, EmployeeId;
```

### Результат

В отделе 1 сумма 240000 и средняя 60000, в отделе 2 — 171000 и 57000; значения повторяются для каждого сотрудника отдела. (ожидаемый, проверить в SSMS).

### Вывод

Оконные агрегаты считают статистику без сворачивания строк.

## Задание 25 — CTE

### SQL

```sql
WITH AvgSalary AS
(
    SELECT AVG(Salary) AS Value FROM Employees
)
SELECT e.EmployeeName, e.Salary
FROM Employees e CROSS JOIN AvgSalary a
WHERE e.Salary > a.Value;

WITH DepartmentAverage AS
(
    SELECT d.DepartmentName, AVG(e.Salary) AS AverageSalary
    FROM Departments d
    INNER JOIN Employees e ON e.DepartmentId = d.DepartmentId
    GROUP BY d.DepartmentName
)
SELECT TOP (3) DepartmentName, AverageSalary
FROM DepartmentAverage ORDER BY AverageSalary DESC;
```

### Результат

Первая выборка — 4 сотрудника выше средней; вторая — топ-3: Менеджмент, Разработка, Аналитика. (ожидаемый, проверить в SSMS).

### Вывод

CTE позволяет вынести расчёт в отдельную именованную часть запроса.

## Задание 26 — CASE в SELECT

### SQL

```sql
SELECT EmployeeName, Salary,
       CASE
           WHEN Salary > 60000 THEN 'High'
           WHEN Salary BETWEEN 40000 AND 60000 THEN 'Medium'
           ELSE 'Low'
       END AS SalaryLevel,
       HireDate,
       CASE
           WHEN HireDate < '2020-01-01' THEN 'Senior'
           WHEN HireDate < '2023-01-01' THEN 'Mid'
           ELSE 'Junior'
       END AS Tenure
FROM Employees
ORDER BY EmployeeId;
```

### Результат

Для каждого из 10 сотрудников выводятся SalaryLevel и Tenure. У сотрудников с зарплатой 60000 и ниже, но не ниже 40000, уровень Medium. (ожидаемый, проверить в SSMS).

### Вывод

CASE формирует значения по условиям без изменения таблицы.
