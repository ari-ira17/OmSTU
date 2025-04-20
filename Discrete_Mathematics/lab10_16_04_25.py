def output():
    for I in range(0, len(matrix)):
        for J in range(0, len(matrix[I])):
            print(matrix[I][J], end='\t')
        print(' ')
    print(' ')


def count_deltas(y, x):
    sum1 = []
    sum2 = []
    for I in range(0, len(matrix)):
        if I != y and I != x:
            sum1.append(matrix[I][x])
    for J in range(0, len(matrix[y])):
        if J != x and J != y:
            sum2.append(matrix[y][J])
    return min(sum1) + min(sum2)


def delete_stroku_stolbec(y, x):
    global matrix
    stroki.remove(y)
    stolbci.remove(x)
    for I in range(0, len(matrix)):
        matrix[I][x] = inf
    for J in range(0, len(matrix[y])):
        matrix[y][J] = inf


def zapret_way(): # to do
    global way
    global matrix
    if len(way) == 1:
        matrix[way[0][1]][way[0][0]] = inf
    if way == 2:
        if way[0][0] == way[1][1]:
            matrix[way[0][1]][way[1][0]] = inf
            print(way[0][1], way[1][0])
        elif way[0][1] == way[1][0]:
            matrix[way[0][0]][way[1][1]] = inf
            print(way[0][0], way[1][1])
        else:
            matrix[way[1][1]][way[1][0]] = inf
            print(way[1][1], way[1][0])


# сумма минимальных по столбцам и строкам - минимальная граница

# нахождение степеней нулей (минимальное значение в строке и столбце за исключением этого элемента)

# куда берем ноль с максимальной степенью - мин граница, в другую сторону прибавляем степень нуля к мин границе

# уничтожаем строку и столбец и добавляем ячейку бесконечности
# на итерации: минимумы по строке, уменьшили, минимумы по слобцам, уменьшили, сложили, посчитали оценку, посчитали степени нуля, выбрали наибольшую

inf = float('inf')
matrix = [
    [inf, 41, 80, 23, 32],
    [41, inf, 45, 12, 37],
    [80, 45, inf, 50, 64],
    [23, 12, 50, inf, 67],
    [32, 37, 64, 67, inf]
]
stolbci = [i for i in range(0, len(matrix))]
stroki = [i for i in range(0, len(matrix))]
way = []

# ITERATION
while len(stolbci) + len(stroki) != 4:
    # alpha count
    alpha = [min(x) for x in matrix]
    print(alpha)

    # - alpha
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if matrix[i][j] != inf:
                matrix[i][j] = matrix[i][j] - alpha[i]
    print("after alpha")
    output()

    # beta count
    beta = [x for x in matrix[0]]
    for i in range(1, len(matrix)):
        for j in range(0, len(matrix[i])):
            beta[j] = min(beta[j], matrix[i][j])
    print(beta)

    # - beta
    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if matrix[i][j] != inf:
                matrix[i][j] = matrix[i][j] - beta[j]
    print("after beta")
    output()

    mark = sum(alpha + beta)
    deltas = []

    for i in range(0, len(matrix)):
        for j in range(0, len(matrix[i])):
            if matrix[i][j] == 0:
                deltas.append([i, j, count_deltas(i, j)])
    print(deltas)
    max_delta = 0
    for i in range(1, len(deltas)):
        if deltas[i][2] > deltas[max_delta][2]:
            max_delta = i
    print(max_delta)
    way.append([deltas[max_delta][0], deltas[max_delta][1]])
    print(f'Going [{deltas[max_delta][0]},  {deltas[max_delta][1]}]')

    delete_stroku_stolbec(deltas[max_delta][0], deltas[max_delta][1])
    zapret_way()
    output()
    print(f'Путь: {way}')
    print(stolbci)
    print(stroki)
    print('-------')
