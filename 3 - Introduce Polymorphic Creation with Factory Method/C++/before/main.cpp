#include <gtest/gtest.h>

#include "TestDomBuilder.h"
#include "TestXmlBuilder.h"

TEST_F(TestDomBuilder, TestAddAboveRoot)
{
  this->TestAddAboveRoot();
}

TEST_F(TestXmlBuilder, TestAddAboveRoot)
{
  this->TestAddAboveRoot();
}


int main(int argc, char **argv)
{
  testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}