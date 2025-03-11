start = int(input("Введите начальную вершину - ")) - 1
end = int(input("Введите конечную вершину - ")) - 1

matrix = [[0, 3, 46, 12, 0],
          [3, 0, 89, 7, 0],
          [46, 0, 0, 2, 6],
          [12, 89, 2, 0, 3],
          [0, 7, 6, 3, 0]]

size = len(matrix)
infinity = max([max(line) for line in matrix]) * 1000
visited_points = [start]
point_now = start
distance = matrix[start][:]
local_min = min([i for i in matrix[point_now] if i != 0])

for k in range(len(distance)):
    if distance[k] == 0 and k != start:
        distance[k] = infinity

while point_now != end:
    for i in range(size):
        if i == point_now and len(visited_points) != len(matrix):
            for j in range(size):
                if j not in visited_points and i != j and matrix[i][j] != 0:
                    distance[j] = min(distance[j], local_min + matrix[i][j])
            local_min = min([i for i in distance if i != 0 and distance.index(i) not in visited_points])
            point_now = distance.index(local_min)
            visited_points.append(point_now)

print("Длина маршрута =", distance[point_now])

previous_points = [point_now]

while point_now != start:
    column = [row[point_now] for row in matrix]
    for t in range(size):
        if column[t] + distance[t] == distance[point_now]:
            point_now = t
    previous_points.append(point_now)

previous_points = [el + 1 for el in previous_points]

print("Маршрут проходит через вершины:", *previous_points)

