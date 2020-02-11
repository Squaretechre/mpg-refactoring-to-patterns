class DOMBuilder:

    def __init__(self, root_name):
        self._node = root_name

    def add_below(self, node):
        pass

    def add_above(self, node):
        raise RuntimeError()
