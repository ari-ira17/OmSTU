matrix = [[0, 1, 0, 0, 3],
          [0, 0, 8, 7, 1],
          [0, 0, 0, 1, -5],
          [0, 0, 2, 0, 0],
          [0, 0, 0, 4, 0]]

size = len(matrix[0])

for i in range(size):
    for j in range(size):
        if matrix[i][j] == 0:
            matrix[i][j] = float('inf')


table = [[float('inf')] * size for _ in range(size)]
table[0][0] = 0

for k in range(1, size):
    for i in range(size):
        for j in range(size):
            if matrix[j][i] != float('inf'):
                if table[j][k - 1] + matrix[j][i] < table[i][k]:
                    table[i][k] = table[j][k - 1] + matrix[j][i]

table_copy = table[::]
for k in range(1, size):
    for i in range(size):
        for j in range(size):
            if matrix[j][i] != float('inf'):
                if table_copy[j][k - 1] + matrix[j][i] < table_copy[i][k]:
                    table_copy[i][k] = table_copy[j][k - 1] + matrix[j][i]

if table == table_copy:
    for m in range(len(table)):
        print(table[m])
else:
    print("В графе есть отрицательный цикл")
