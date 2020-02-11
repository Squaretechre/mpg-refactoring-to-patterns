from abstract_builder_test import AbstractBuilderTest
from xml_builder import XMLBuilder


class TestXMLBuilder(AbstractBuilderTest):
    def test_add_above_root(self):
        self.add_above_root()

    def create_builder(self, root_name):
        return XMLBuilder(root_name)

