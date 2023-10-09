from shape import Shape
from grid import Grid
import random as rand

#Create grid with random dim 
GRID_X,GRID_Y = rand.randint(4,4),rand.randint(3,3) 
grid = Grid(GRID_X, GRID_Y)
A = Shape('A', 'd r')
B = Shape('B', 'l d')
shapes = [A,B]

shape_loop_counter = 0
while shape_loop_counter < len(shapes):
  shape = shapes[shape_loop_counter]
  free_cells = grid.get_free()
  
  while len(free_cells) > 0:
    idx = rand.randint(0, len(free_cells)-1) 
    x,y = free_cells[idx]
    if grid.add(shape,x,y): 
      shape_loop_counter+=1
      break
    else:
      del free_cells[idx]
grid.out()

#print(A.get(), B.get(), A.compare(B))
