matrix = [[0, 1, 0, 1, 0, 0, 0, 0, 0],
          [1, 0, 1, 1, 0, 0, 0, 0, 0],
          [0, 1, 0, 0, 0, 0, 0, 0, 0],
          [1, 1, 0, 0, 0, 1, 1, 0, 0],
          [0, 0, 0, 0, 0, 0, 0, 1, 1],
          [0, 0, 0, 1, 0, 0, 1, 0, 0],
          [0, 0, 0, 1, 0, 1, 0, 0, 0],
          [0, 0, 0, 0, 1, 0, 0, 0, 1],
          [0, 0, 0, 0, 1, 0, 0, 1, 0]]


# 1-ый алгоритм (формирование очереди)

points = [0, 1, 2, 3, 4, 5, 6, 7, 8]

max_index = len(matrix[0]) + 1
start_index = 0
visited_points = [start_index]
points.remove(start_index)
areas_counter = 0

while len(points) != 0:
    points_search = visited_points[-1]

    for i in range(len(matrix[points_search])):
        point_now = matrix[points_search][i]
        if point_now == 1 and i not in visited_points:
            visited_points.append(i)
            points.remove(i)
            points_search = min(max_index, i)
        elif point_now == 1 and i in visited_points:

            points_search = min(points)
            visited_points = [min(points)]
            points.remove(min(points))
            areas_counter += 1

print("Число компонент графа =", areas_counter)


# 2-ой алгоритм (полный перебор)

size = 9
components = [1] + [size] * (size - 1)
component_counter = 1
previos_points = [0]

for i in range(1, size):
    previos_points.append(i)

    if all([matrix[i][j] == 0 for j in range(len(previos_points))]):
        component_counter += 1
        components[i] = component_counter
    else:
        components[i] = components[matrix[i].index(1)]
        for j in range(len(previos_points)):
            if matrix[i][j] == 1 and components[j] > components[i]:
                components[j] = components[i]

print("Число компонент в графе = ", len(set(components)))

