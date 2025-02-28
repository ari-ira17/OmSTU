def searching_edges(mat):
    matrix = mat
    points = [x for x in range(len(matrix[0]))]
    size = len(matrix[0])
    visited_points = []
    edges_trees = []
    maxs = [max(m) for m in matrix]
    searching_min = max(maxs)
    i_min = j_min = 0

    while len(points) != 0:

        if len(points) == size:
            for i in range(size):
                for j in range(i + 1, size):
                    if matrix[i][j] <= searching_min and matrix[i][j] != 0:
                        searching_min = matrix[i][j]
                        i_min = i
                        j_min = j
            matrix[i_min][j_min] = 0
            points.remove(i_min)
            points.remove(j_min)
            visited_points.append(i_min)
            visited_points.append(j_min)
            edges_trees.append([i_min, j_min])
            searching_min = max(maxs)

        else:
            for i in range(size):
                for j in range(i + 1, size):
                    if ((i in visited_points) ^ (j in visited_points)) and matrix[i][j] <= searching_min and matrix[i][j] != 0:
                        searching_min = matrix[i][j]
                        i_min = i
                        j_min = j
            matrix[i_min][j_min] = 0
            if i_min not in visited_points:
                points.remove(i_min)
                visited_points.append(i_min)
                edges_trees.append([i_min, j_min])
            elif j_min not in visited_points:
                points.remove(j_min)
                visited_points.append(j_min)
                edges_trees.append([i_min, j_min])
            searching_min = max(maxs)

    return edges_trees


def counting_components(mat):
    matrix = mat
    size = len(matrix[0])
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

    return len(set(components))


matrix = [[0, 5, 0, 0, 11, 0, 8],       # матрица весов для подсчета остовного дерева
          [5, 0, 9, 0, 0, 0, 4],
          [0, 9, 0, 0, 0, 15, 8],
          [0, 0, 0, 0, 20, 0, 0],
          [11, 0, 0, 20, 0, 19, 3],
          [0, 0, 15, 0, 19, 0, 5],
          [8, 4, 8, 0, 3, 5, 0]]

edges_trees = searching_edges(matrix)       # нашли ребра остновного дерева

for i in range(len(matrix[0])):
    for j in range(len(matrix[0])):
        if matrix[i][j] != 0:
            matrix[i][j] = 1        # матрица смежности для подсчета компонент связности

bridges = 0

for i in range(len(edges_trees)):
    matrix_copy = [row[:] for row in matrix]
    matrix_copy[edges_trees[i][0]][edges_trees[i][1]] = 0
    matrix_copy[edges_trees[i][1]][edges_trees[i][0]] = 0
    components_now = counting_components(matrix_copy)
    if components_now != 1:
        bridges += 1

print("Число мостов =", bridges)
