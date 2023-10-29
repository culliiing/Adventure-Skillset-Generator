from regex import D
from classes import Grid, Shape, Solver
import random as rand
from os import system

system('cls')
print('Output:\n')

# Create grid with random dim
# 4x3 grid with A, B and C has only one solution, but 4x3 has two.
GRID_X, GRID_Y = rand.randint(2, 2), rand.randint(2, 2)
#grid = Grid(GRID_X, GRID_Y)

# Create three shapes A, B and C.
A = Shape('A', 'r')
B = Shape('B', '')
#C = Shape('C', 'd r u')
#D = Shape('D', 'l l')
shapes = [A, B]

solver = Solver()
x, y, grids = solver.get_grids(shapes)
print(x, y)
for grid in grids:
    grid.out()
    print()
#print(A.get(), B.get(), A.compare(B))
