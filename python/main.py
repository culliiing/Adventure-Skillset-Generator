from shape import Shape
from grid import Grid
import random as rand
from time import sleep
from os import system

system('cls')
print('Output:\n')

# Create grid with random dim
GRID_X, GRID_Y = rand.randint(3, 5), rand.randint(3, 5)
grid = Grid(GRID_X, GRID_Y)

# Create two shapes A and B
A = Shape('A', 'd r')
B = Shape('B', 'l d')
C = Shape('C', 'd r u')
shapes = [A, B, C]

print(grid.add_shapes(shapes))

grid.out()

#print(A.get(), B.get(), A.compare(B))
