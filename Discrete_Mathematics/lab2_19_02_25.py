matrix = [[0, 5, 0, 0, 2, 4],
          [5, 0, 12, 0, 0, 1],
          [0, 12, 0, 9, 0, 3],
          [0, 0, 9, 0, 7, 10],
          [2, 0, 0, 7, 0, 8],
          [4, 1, 3, 10, 8, 0]]

# 1-ый алгоритм (Прима)

size = len(matrix[0])
start = 0
points = [i for i in range(size)]

visited_points = [0]
points.remove(0)
searching_area = [[] for _ in range(size)]
route_length = 0

while len(points) != 0:

    for i in range(size):
        for j in range(size):
            if i in visited_points and j not in visited_points:
                searching_area[i].append(matrix[i][j])

    min_elements = []
    min_elements_indexes = []
    for k in range(len(searching_area)):
        searching_area_now_copy = searching_area[k][:]
        searching_area_now_copy.sort()
        for item in searching_area_now_copy:
            if item != 0:
                min_elements.append(item)
                min_elements_indexes.append(matrix[k].index(item))
                break
    min_element = min(min_elements)
    min_element_index = min_elements_indexes[min_elements.index(min_element)]

    route_length += min_element
    visited_points.append(min_element_index)
    points.remove(min_element_index)

    # очистить рабочую область
    searching_area = [[] for _ in range(size)]

print("Вес оставного дерева =", route_length)



# 2-ой алгоритм (Крускалло)

points_ = [x for x in range(len(matrix[0]))]
size_ = len(matrix[0])
visited_points_ = []
maxs = [max(m) for m in matrix]
searching_min = max(maxs)
i_min = j_min = 0
route_length_ = 0

while len(points_) != 0:

    if len(points_) == size_:
        for i in range(size_):
            for j in range(i + 1, size_):
                if matrix[i][j] <= searching_min and matrix[i][j] != 0:
                    searching_min = matrix[i][j]
                    i_min = i
                    j_min = j
        route_length_ += searching_min
        matrix[i_min][j_min] = 0
        points_.remove(i_min)
        points_.remove(j_min)
        visited_points_.append(i_min)
        visited_points_.append(j_min)
        searching_min = max(maxs)
    else:
        for i in range(size_):
            for j in range(i + 1, size_):
                if ((i in visited_points_) ^ (j in visited_points_)) and matrix[i][j] <= searching_min and matrix[i][j] != 0:
                    searching_min = matrix[i][j]
                    i_min = i
                    j_min = j
        route_length_ += searching_min
        matrix[i_min][j_min] = 0
        if i_min not in visited_points_:
            points_.remove(i_min)
            visited_points_.append(i_min)
        elif j_min not in visited_points_:
            points_.remove(j_min)
            visited_points_.append(j_min)
        searching_min = max(maxs)

print("Вес оставного дерева =", route_length_)
