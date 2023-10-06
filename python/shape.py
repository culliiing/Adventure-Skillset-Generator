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
            self.queue.sort()

    def get_name(self):
        return self.name

    def compare(self, other):
        if isinstance(other, Shape):
            return self.queue == other.get()
        else:
            return False

    def get(self):
        return self.queue
