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
