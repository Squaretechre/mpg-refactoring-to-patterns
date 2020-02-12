from unittest import TestCase
from xml_builder import XMLBuilder


class TestXMLBuilder(TestCase):
    def test_add_above_root(self):
        invalid_result = """
        <orders>
            <order>
            </order>
        </orders>
        <customer>
        </customer>
        """

        builder = XMLBuilder("orders")
        builder.add_below("order")

        with self.assertRaises(RuntimeError):
            builder.add_above("customer")

