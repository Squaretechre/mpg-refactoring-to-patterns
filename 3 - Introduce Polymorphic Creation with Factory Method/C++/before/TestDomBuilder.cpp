#include "TestDomBuilder.h"

#include <gtest/gtest.h>

#include "DomBuilder.h"

void TestDomBuilder::TestAddAboveRoot()
{
  Builder = std::unique_ptr<DomBuilder>(new DomBuilder("orders"));
  ASSERT_NO_THROW(Builder->AddBelow("customer"));
  ASSERT_ANY_THROW(Builder->AddAbove("customer"));
}
