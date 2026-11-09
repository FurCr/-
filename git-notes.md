\# Git notes



\## Task 15 — Basic git

\### Commands

git checkout -b feature/git-basics

git merge feature/git-basics





\### Output (git log --graph --oneline --all)

\*   fb43ce8 (HEAD -> main, origin/main) merge: resolve conflict in README

|\\

| \* a78a389 (origin/feature/git-basics, feature/git-basics) docs: change line in branch

| \* a7172e1 docs: add line for git basics

\* | 604b698 docs: change line in main

|/

\* 5d166e8 feat: task 14 - age calculator

\* 7ef1bca feat: tasks 12-13 - palindrome and word counter

\* 1995fae feat: tasks 10-11 - sorting and matrix diagonal

\* 75d61c7 feat: tasks 08-09 - fizzbuzz and array stats

\* e00371e feat: tasks 06-07 - digit sum and string reverse

\* 0557446 feat: tasks 04-05 - even odd and multiplication table

\* 3f7e95b feat: tasks 02-03 - primitives, calculator and fix folders

\* 82c4d7c feat: task 01 - project skeleton and hello world



\### What I learned

Научился создавать ветки, сливать их (merge). Понял, что конфликт возникает, когда две ветки меняют одну строку. Его нужно решать вручную: открыть файл, удалить маркеры <<<<<<<, =======, >>>>>>> и оставить нужный текст.

