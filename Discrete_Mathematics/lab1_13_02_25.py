matrix = [[0, 1, 0, 1, 0, 0, 0, 0, 0],
          [1, 0, 1, 1, 0, 0, 0, 0, 0],
          [0, 1, 0, 0, 0, 0, 0, 0, 0],
          [1, 1, 0, 0, 0, 1, 1, 0, 0],
          [0, 0, 0, 0, 0, 0, 0, 1, 1],
          [0, 0, 0, 1, 0, 0, 1, 0, 0],
          [0, 0, 0, 1, 0, 1, 0, 0, 0],
          [0, 0, 0, 0, 1, 0, 0, 0, 1],
          [0, 0, 0, 0, 1, 0, 0, 1, 0]]

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























