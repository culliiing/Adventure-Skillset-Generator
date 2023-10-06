class Grid:
  
  def __init__(self, x,y):
    self.matrix = [[' ' for j in range(y)] for i in range(x)]

  def out(self):
    matrix = self.matrix
    for row in matrix:
      print(('|'+'{}'*len(row)).format(*['{}|'.format(c) for c in row]))
  
  def add(self,shape, x, y):
    matrix = self.matrix
    name = shape.get_name()
    for cell in shape.get():
      shape_x, shape_y = cell
      temp_x = shape_x + x
      temp_y = shape_y + y
      if  temp_x >= 0 and temp_x < len(matrix) and temp_y >= 0 and temp_y < len(matrix[0]):
        if matrix[temp_x][temp_y] == ' ':
          matrix[temp_x][temp_y] = name
