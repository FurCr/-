# Git notes



## Task 15 — Basic git

### Commands

git checkout -b feature/git-basics

git merge feature/git-basics





### Output (git log --graph --oneline --all)

```text
*   fb43ce8 (HEAD -> main, origin/main) merge: resolve conflict in README

|\\

| * a78a389 (origin/feature/git-basics, feature/git-basics) docs: change line in branch

| * a7172e1 docs: add line for git basics

* | 604b698 docs: change line in main

|/

* 5d166e8 feat: task 14 - age calculator

* 7ef1bca feat: tasks 12-13 - palindrome and word counter

* 1995fae feat: tasks 10-11 - sorting and matrix diagonal

* 75d61c7 feat: tasks 08-09 - fizzbuzz and array stats

* e00371e feat: tasks 06-07 - digit sum and string reverse

* 0557446 feat: tasks 04-05 - even odd and multiplication table

* 3f7e95b feat: tasks 02-03 - primitives, calculator and fix folders

* 82c4d7c feat: task 01 - project skeleton and hello world
```

### What I learned

Научился создавать ветки, сливать их (merge). Понял, что конфликт возникает, когда две ветки меняют одну строку. Его нужно решать вручную: открыть файл, удалить маркеры <<<<<<<, =======, >>>>>>> и оставить нужный текст.


## Задание 35

Ветка для PR: `feature/task-35-check`.
PR: https://github.com/FurCr/-/pull/1 — объединён с `main`.

`.gitignore`: bin/, obj/, .vs/, *.user.
`.editorconfig`: UTF-8 и отступы в 4 пробела.

Ветка для объединения: `feature/rebase-demo`.
Три небольших коммита объединены в один.

### git log --oneline (после объединения)

```text
dfad94a docs: task 35 - rebase
a7a25d6 feat: task 35 - git
5d10ab2 chore: add gitignore and editorconfig
7d14070 feat: task 34 - word groups
1e114db feat: task 33 - employees
```

## Задание 46 — stash

Проверка в отдельном локальном Git-репозитории:

```text
git stash
Saved working directory and index state On main: task 46 temporary edit
git stash list
stash@{0}: On main: task 46 temporary edit
git switch -c feature/stash-demo
git switch main
git stash pop
После pop: git stash list пуст, строка из README восстановлена.
```

## Задание 47 — rebase -i

Проверка в отдельном локальном Git-репозитории.

До `git rebase -i HEAD~4`:

```text
420a549 docs: note 4
fa823db docs: note 3
501f187 docs: note 2
195ad8f docs: note 1
```

После объединения:

```text
ea5e5b2 docs: note 1
5bbef59 init: local git exercise
```

В ветке GitHub `feature/squash-demo` четыре коммита тоже свёрнуты в один.

## Задание 48 — аннотированный тег

В отдельном учебном локальном репозитории:

```text
git tag -a v1.0.0 -m "Release v1.0.0"
git tag
v1.0.0
git show v1.0.0 --no-patch
tag v1.0.0
Release v1.0.0
commit 4ad9f61 docs: recovery practice
```

В удалённый репозиторий тег ещё не отправлен.

## Задание 49 — reflog

В отдельном учебном локальном репозитории:

```text
Создан коммит: 4ad9f61 docs: recovery practice
git reset --hard HEAD~1
git reflog
5bbef59 reset: moving to HEAD~1
4ad9f61 commit: docs: recovery practice
git reset --hard 4ad9f61
git log --oneline
4ad9f61 docs: recovery practice
5bbef59 init: local git exercise
```

## Задание 50 — bisect

Проверка в отдельном учебном локальном репозитории, 11 коммитов. В шестом коммите значение изменено с `result=10` на `result=9`.

```text
git bisect start
git bisect bad HEAD
git bisect good <первый рабочий коммит>
9c77bb4 bad
c8cbe6c good
f852b5e good
9c77bb4 is the first bad commit
git bisect reset
Switched to branch 'main'
```
