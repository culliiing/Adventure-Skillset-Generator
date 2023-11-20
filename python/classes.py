import math
import random as rand
from time import sleep
from copy import deepcopy


class Shape:
    def __init__(self, name, string):
        self.queue = [(0, 0)]
        self.name = name
        for operation in string.split():
            last_cell = self.queue[-1]
            x, y = last_cell
            match operation:
                case 'r':
                    y += 1
                case 'd':
                    x += 1
                case 'l':
                    y -= 1
                case 'u':
                    x -= 1
            if not self.queue.__contains__((x, y)):
                print(operation, x, y)
                self.queue.append((x, y))

    def get_name(self):
        return self.name

    def compare(self, other):
        if isinstance(other, Shape):
            count = 0
            for i in range(4):
                ang = i * math.pi/2
                queue = sorted([(round(cell[0] * math.cos(ang) - cell[1] * math.sin(ang)),
                                 round(cell[0] * math.sin(ang) + cell[1] * math.cos(ang))) for cell in self.queue])
                if queue == other.get():
                    count += 1
            return count > 0
        else:
            return False

    def get(self):
        return self.queue


class Grid:
    def __init__(self, x, y):
        self.matrix = [[" " for j in range(y)] for i in range(x)]

    def copy(self):
        matrix = deepcopy(self.matrix)
        new_grid = Grid(len(matrix), len(matrix[0]))
        new_grid.matrix = matrix
        return new_grid

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


class Solver:
    def get_grids(self, shapes):
        for i in range(len(shapes)-1):
            for j in range(i+1, len(shapes)):
                if(shapes[i].compare(shapes[j])):
                    print("Couldn't add shapes cause",
                          shapes[i].get_name(), "and", shapes[j].get_name(), "are the same.")
                    return
        x = 1
        y = 1
        c = 0
        while True:
            grids = []
            self._rec(shapes, Grid(x, y), grids)
            if len(grids) > 0:
                return x, y, grids

            if c % 3 % 2 == 0:
                x += 1
            else:
                x -= 1
                y += 1
            c += 1

    def _rec(self, shapes, grid, grids):
        num = len(shapes)
        if num == 0:
            grids.append(grid)
            return

        shape = shapes[0]
        name = shape.get_name()
        free_cells = grid.get_free()
        while len(free_cells) > 0:
            passable_grid = grid.copy()
            idx = rand.randint(0, len(free_cells) - 1)
            x, y = free_cells[idx]
            addMe = passable_grid.add(shape, x, y)
            if addMe:
                self._rec(shapes[1:], passable_grid, grids)
            del free_cells[idx]
        # Leave these comments here, they are used during dev.
        #print(name, x, y, addMe, free_cells)
        #self.out(x, y)
