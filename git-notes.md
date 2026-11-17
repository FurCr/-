# Git notes

## Задание 15 — ветки и merge

Схема действий, соответствующая сохранённой истории Git:

```bash
git switch main
git switch -c feature/git-basics
# Изменить строку в README.md
git add README.md
git commit -m "docs: change line in branch"
git switch main
# Изменить ту же строку README.md по-другому
git add README.md
git commit -m "docs: change line in main"
git merge feature/git-basics
# После конфликта вручную исправить README.md
git add README.md
git commit -m "merge: resolve conflict in README"
git log --graph --oneline --all
```

В отдельном новом репозитории начало сценария выполняется через `git init -b main`. Команды выше показаны для уже созданного репозитория.

Из первоначальной истории:

```text
fb43ce8 merge: resolve conflict in README
a78a389 docs: change line in branch
a7172e1 docs: add line for git basics
604b698 docs: change line in main
```

При конфликте удаляются маркеры `<<<<<<<`, `=======`, `>>>>>>>` и сохраняется нужный вариант текста.

## Задание 35 — Pull Request и rebase

Ветка для PR: `feature/task-35-check`. [PR #1](https://github.com/FurCr/-/pull/1) объединён с `main`.

```text
dfad94a docs: task 35 - rebase
a7a25d6 feat: task 35 - git
5d10ab2 chore: add gitignore and editorconfig
```

Три коммита с записями объединены в один в ветке `feature/rebase-demo`.

## Задание 46 — stash

```bash
git stash
git stash list
git switch -c exercise-stash
git switch main
git stash pop
git stash list
```

```text
До pop: stash@{0}: On main: task 46 change
После pop: список stash пуст, изменение в файле восстановлено.
```

## Задание 47 — rebase -i

В локальном учебном репозитории созданы четыре коммита, затем выполнено `git rebase -i HEAD~4`.

До:

```text
7ff9ed9 docs: note 4
b45c74e docs: note 3
8caffac docs: note 2
5d4f2b5 docs: note 1
```

После:

```text
8754ae6 docs: note 1
33946b0 chore: start
```

В GitHub есть ветка `feature/squash-demo` с одним объединённым коммитом `81aac01`.

## Задание 48 — тег

```bash
git tag -a v1.0.0 -m "Release v1.0.0"
git tag
git show v1.0.0
```

```text
v1.0.0
tag v1.0.0
Release v1.0.0
```

Тег создан в локальном учебном репозитории; в `FurCr/-` на GitHub он пока не опубликован.

## Задание 49 — reflog

```bash
git reset --hard HEAD~1
git reflog
git reset --hard 1a83fbc
git log --oneline
```

```text
8754ae6 reset: moving to HEAD~1
1a83fbc commit: docs: recovery practice

1a83fbc docs: recovery practice
8754ae6 docs: note 1
```

Удалённый из истории коммит восстановлен по хешу из reflog.

## Задание 50 — bisect

В отдельном учебном репозитории создано 11 коммитов. Ошибка появилась в шестом.

```bash
git bisect start
git bisect bad HEAD
git bisect good <первый рабочий коммит>
git bisect run sh -c 'grep -q "^10$" result.txt'
git bisect reset
```

```text
78ddfebf63a2defca7c0af2b9703101e30ee1b9d is the first bad commit
bisect found first bad commit
```
