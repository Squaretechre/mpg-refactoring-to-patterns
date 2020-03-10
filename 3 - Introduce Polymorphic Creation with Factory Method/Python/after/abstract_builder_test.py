from abc import abstractmethod
from unittest.case import TestCase


class AbstractBuilderTest(TestCase):
    def add_above_root(self):
        invalid_result = """
        <orders>
            <order>
            </order>
        </orders>
        <customer>
        </customer>
        """

        root_name = "orders"
        builder = self.create_builder(root_name)
        builder.add_below("order")

        with self.assertRaises(RuntimeError):
            builder.add_above("customer")

    @abstractmethod
    def create_builder(self, root_name):
        pass
