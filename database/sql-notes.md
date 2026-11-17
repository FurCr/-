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
