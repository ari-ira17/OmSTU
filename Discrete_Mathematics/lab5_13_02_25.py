matrix = [[0, 10, 18, 8, 0, 0],
          [10, 0, 16, 9, 21, 0],
          [0, 16, 0, 0, 0, 15],
          [7, 9, 0, 0, 0, 12],
          [0, 0, 0, 0, 0, 23],
          [0, 0, 15, 0, 23, 0]]

infinity = max([max(line) for line in matrix]) * 1000
size = len(matrix[0])
searching_matrix = matrix[:]
searching_matrix[0] = matrix[0]

for i in range(size):
    for j in range(size):
        if matrix[i][j] == 0 and i != j:
            matrix[i][j] = infinity

for k in range(1, size):
    for i in range(size):
        for j in range(size):
            searching_matrix[i][j] = min(matrix[i][k] + matrix[k][j], matrix[i][j])

print("    1     2     3    4     5    6")

for i in range(size):
    print(i + 1, end=' ')
    for j in range(size):
        print("|", searching_matrix[i][j], end='  ')
    print()
