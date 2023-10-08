import math 
class Shape:

    def __init__(self, name, string):
        self.queue = [(0, 0)]
        self.name = name
        for operation in string.split():
            last_cell = self.queue[-1]
            match operation:
                case 'r':
                    self.queue.append((last_cell[0], last_cell[1]+1))
                case 'd':
                    self.queue.append((last_cell[0]+1, last_cell[1]))
                case 'l':
                    self.queue.append((last_cell[0], last_cell[1]-1))
                case 'u':
                    self.queue.append((last_cell[0]-1, last_cell[1]))

    def get_name(self):
        return self.name

    def compare(self, other):
        if isinstance(other, Shape):
            print('Comparing ',self.name, ' to ', other.get_name(), ':')
            count = 0
            for i in range(4):     
              ang = i * math.pi/2
              queue = sorted([( round(cell[0] * math.cos(ang) - cell[1] * math.sin(ang)),
                                round(cell[0] * math.sin(ang) + cell[1] * math.cos(ang))) for cell in self.queue])
              print(self.name, 'with angle', math.degrees(ang), '=', queue)
              if queue == other.get():
                  count+=1
            return count>0
        else:
            return False

    def get(self):
        return sorted(self.queue)
