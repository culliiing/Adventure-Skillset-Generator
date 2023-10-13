import random as rand
from time import sleep
from copy import deepcopy


class Grid:
    def __init__(self, x, y):
        self.matrix = [[" " for j in range(y)] for i in range(x)]

    def out(self, x=-1, y=-1):
        """
        Prints out the grid. If a point is given, a X is printed at that point (used only when we know that the point is empty, but still print the old value if we overwrite one).
        """
        matrix = deepcopy(self.matrix)
        if self._in_bounds(x, y):
            if matrix[x][y] != " ":
                print("X just replaced", matrix[x][y])
            matrix[x][y] = "X"
        for row in matrix:
            print(("|" + "{}" * len(row)).format(*
                  ["{}|".format(c) for c in row]))

    def get_free(self):
        """
        Returns all the current free cells.

        Return:
            list
        """
        x_dim = len(self.matrix)
        y_dim = len(self.matrix[0])
        free = []
        for x in range(x_dim):
            for y in range(y_dim):
                if self.matrix[x][y] == " ":
                    free.append((x, y))
        return sorted(free)

    def add_shapes(self, shapes):
        num = len(shapes)
        if num == 0:
            return True

        shape = shapes[0]
        name = shape.get_name()
        free_cells = self.get_free()
        while len(free_cells) > 0:
            idx = rand.randint(0, len(free_cells) - 1)
            x, y = free_cells[idx]
            addMe = self.add(shape, x, y)
            if addMe:
                addRest = self.add_shapes(shapes[1:])
                if addRest:
                    return addMe and addRest
                else:
                    self._clear(shape.get(), x, y)
                    del free_cells[idx]
            else:
                del free_cells[idx]
            print(name, x, y, addMe, free_cells)
            self.out(x, y)
            # sleep(0.1)
        return False

    def add(self, shape, x, y):
        matrix = self.matrix
        name = shape.get_name()
        cells = shape.get()
        added = []
        for i in range(len(cells)):
            shape_x, shape_y = cells[i]
            temp_x = shape_x + x
            temp_y = shape_y + y
            if self._in_bounds(temp_x, temp_y):
                if matrix[temp_x][temp_y] == " ":
                    matrix[temp_x][temp_y] = name
                    added.append((temp_x, temp_y))
                else:
                    # print(f'{name} taken at {(temp_x,temp_y)}')
                    self._clear(added)
                    return False
            else:
                # print(f'{name} out_of_bounds at {(temp_x,temp_y)}')
                self._clear(added)
                return False
        return True

    def _clear(self, cells, ofX=0, ofY=0):
        matrix = self.matrix
        for x, y in cells:
            x += ofX
            y += ofY
            if self._in_bounds(x, y):
                matrix[x][y] = " "

    def _in_bounds(self, x, y):
        return x >= 0 and x < len(self.matrix) and y >= 0 and y < len(self.matrix[0])
