from abstract_builder_test import AbstractBuilderTest
from dom_builder import DOMBuilder


class TestDOMBuilder(AbstractBuilderTest):
    def test_add_above_root(self):
        self.add_above_root()

    def create_builder(self, root_name):
        return DOMBuilder(root_name)

