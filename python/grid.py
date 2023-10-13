import random as rand

class Grid:
  
  def __init__(self, x,y):
    self.matrix = [[' ' for j in range(y)] for i in range(x)]

  def out(self):
    matrix = self.matrix
    for row in matrix:
      print(('|'+'{}'*len(row)).format(*['{}|'.format(c) for c in row]))
  
  def get_free(self):
    return sorted([(idx%len(self.matrix),idx%len(self.matrix[0])) for idx in range(len(self.matrix) * len(self.matrix[0])) if self.matrix[idx%len(self.matrix)][idx%len(self.matrix[0])] == ' '])

  def add_shapes(self, shapes):
    num = len(shapes)
    if num > 0:
      shape = shapes[0]
      if num == 1:    
        return self.try_cells(shape, self.get_free())
      
      return self.try_cells(shape, self.get_free()) and self.add_shapes(shapes[1:])
    else:
      raise Exception('Length of shapes must be bigger than 0.')

  def try_cells(self, shape, cells):
    free_cells = cells
    while len(free_cells) > 0:
      idx = rand.randint(0, len(free_cells)-1)
      x, y = free_cells[idx]
      added = self.add(shape, x, y)
      if added:
        return True
      else:
        del free_cells[idx]
    return False

  def add(self,shape, x, y):
    matrix = self.matrix
    name = shape.get_name()
    cells  = shape.get()
    added = []
    for i in range(len(cells)):
      shape_x, shape_y = cells[i]
      temp_x = shape_x + x
      temp_y = shape_y + y
      if self._in_bounds(temp_x, temp_y):
        if matrix[temp_x][temp_y] == ' ':
          matrix[temp_x][temp_y] = name
          added.append((temp_x,temp_y))
        else: 
          print(f'{name} taken at {(temp_x,temp_y)}')
          self._clear(added)
          return False
      else:
        print(f'{name} out_of_bounds at {(temp_x,temp_y)}')
        self._clear(added)
        return False
    return True
  
  def _clear(self, cells):
    matrix = self.matrix
    for x,y in cells:
      if self._in_bounds(x, y):
        matrix[x][y] = ' '
  
  def _in_bounds(self,x,y):
    return x >= 0 and x < len(self.matrix) and y >= 0 and y < len(self.matrix[0])
      