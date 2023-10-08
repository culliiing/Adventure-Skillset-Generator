from shape import Shape
from grid import Grid

grid = Grid(5, 4)
A = Shape('A', 'd r')
B = Shape('B', 'l d')
grid.add(A, 0, 0)
grid.add(B, 2, 1)
grid.out()

print(A.get(), B.get(), A.compare(B))
