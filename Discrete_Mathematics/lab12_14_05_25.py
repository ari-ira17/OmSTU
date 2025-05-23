def ford_fulkerson(graph, source, sink):
    n = len(graph)
    residual = [row[:] for row in graph]
    parent = [-1] * n
    max_flow = 0

    def dfs(u):
        visited = [False] * n
        stack = [(u, float('inf'))]
        visited[u] = True

        while stack:
            u, current_flow = stack.pop()
            for v in range(n):
                if not visited[v] and residual[u][v] > 0:
                    visited[v] = True
                    parent[v] = u
                    new_flow = min(current_flow, residual[u][v])
                    if v == sink:
                        return new_flow
                    stack.append((v, new_flow))
        return 0

    while True:
        min_flow = dfs(source)
        if min_flow == 0:
            break

        path = []
        v = sink
        while v != -1:
            path.append(v)
            v = parent[v]
        path = path[::-1]

        v = sink
        while v != source:
            u = parent[v]
            residual[u][v] -= min_flow
            residual[v][u] += min_flow
            v = u

        max_flow += min_flow

    return max_flow


graph = [
    [0, 76, 47, 0, 0, 41],
    [0, 0, 0, 0, 44, 56],
    [0, 0, 0, 25, 15, 0],
    [0, 35, 0, 0, 13, 29],
    [0, 0, 0, 0, 0, 50],
    [0, 0, 0, 0, 0, 0]
]

source = 0  # s
sink = 5  # t

max_flow = ford_fulkerson(graph, source, sink)
print(f"Максимальный поток: {max_flow}")
