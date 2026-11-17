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
