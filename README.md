# TicTacToe
тестовое задание: REST API для игры в крестики нолики.
Реализован CRUD: возможность создания игры, доступа к игре по id, хода, удаления игры.
Реализовано хранение информации в postgreSql.
Реализована логика игры.

GetGameById - принимает int id, возвращает поле в виде string cо значениями в виде " ", "Х" или "О". Также выдает сообщение, кто должен ходить следующим.
CreateGame - создает новую игру и возвращает int id.
MakeTurn - принимает int id игры, short номер поля и bool ставить крестик/нолик. Возвращает результат, как GetGameById, в сообщении будет указано, кто ходит следующим, или результ игры. Если игра закончена, она автоматически удаляется.
DeleteGameById - удаляет игру по int id.
