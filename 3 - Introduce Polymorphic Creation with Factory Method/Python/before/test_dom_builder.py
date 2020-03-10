from unittest import TestCase
from before.dom_builder import DOMBuilder


class TestDOMBuilder(TestCase):
    def test_add_above_root(self):
        invalid_result = """
        <orders>
            <order>
            </order>
        </orders>
        <customer>
        </customer>
        """

        builder = DOMBuilder("orders")
        builder.add_below("order")

        with self.assertRaises(RuntimeError):
            builder.add_above("customer")

