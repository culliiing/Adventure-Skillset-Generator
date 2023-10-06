from shape import Shape
from grid import Grid

grid = Grid(5, 4)
A = Shape('A', 'r d l')
B = Shape('B', 'd r u')
grid.add(A, 0, 0)
grid.add(B, 2, 0)
grid.out()
print(A.compare(B))
