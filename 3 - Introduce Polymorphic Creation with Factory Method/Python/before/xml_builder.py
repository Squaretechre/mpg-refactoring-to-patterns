class XMLBuilder:

    def __init__(self, node):
        self._node = node

    def add_below(self, node):
        pass

    def add_above(self, node):
        raise RuntimeError()
