print("Введите координаты начальной вершины - ")
x1, y1 = int(input()), int(input())
print("Введите координаты конечной вершины - ")
x2, y2 = int(input()), int(input())

matrix = [[0, 0, 0, -1, -1],
          [0, -1, 0, 0, 0],
          [0, -1, 0, -1, 0],
          [0, 0, 0, -1, 0],
          [0, 0, 0, -1, 0]]

matrix_copy = []
flag = True

for line in matrix:     # обкладка камнями
    line.insert(0, -1)
    line.append(-1)
matrix.insert(0, [-1] * len(matrix))
matrix.append([-1] * len(matrix))

if matrix[x1 - 1][y1] != -1:        # получили первые единички и с них начнем преобразовывать матрицу
    matrix[x1 - 1][y1] += 1

if matrix[x1 + 1][y1] != -1:
    matrix[x1 + 1][y1] += 1

if matrix[x1][y1 - 1] != -1:
    matrix[x1][y1 - 1] += 1

if matrix[x1][y1 + 1] != -1:
    matrix[x1][y1 + 1] += 1


while any(0 in line for line in matrix) and flag:
    for i in range(1, len(matrix) - 1):        # чтобы не заходить на обкладку камнями идем в тушку матрицы
        for j in range(1, len(matrix) - 1):

            if matrix[i][j] != 0 and matrix[i][j] != -1:

                if matrix[i - 1][j] != -1 and matrix[i - 1][j] == 0:
                    matrix[i - 1][j] += matrix[i][j] + 1

                if matrix[i + 1][j] != -1 and matrix[i + 1][j] == 0:
                    matrix[i + 1][j] += matrix[i][j] + 1

                if matrix[i][j - 1] != -1 and matrix[i][j - 1] == 0:
                    matrix[i][j - 1] += matrix[i][j] + 1

                if matrix[i][j + 1] != -1 and matrix[i][j + 1] == 0:
                    matrix[i][j + 1] += matrix[i][j] + 1

    if matrix_copy == matrix:
        flag = False
    else:
        matrix_copy = [row[:] for row in matrix]


if not flag:
    print("Невозможно достичь конечной вершины")
else:
    print("Число шагов = ", matrix[x2][y2])
