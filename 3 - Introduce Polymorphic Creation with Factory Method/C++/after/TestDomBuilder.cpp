#include "TestDomBuilder.h"

#include <gtest/gtest.h>

#include "DomBuilder.h"

std::unique_ptr<IOutputBuilder> TestDomBuilder::CreateBuilder(std::string root)
{
  return std::unique_ptr<IOutputBuilder>(new DomBuilder(root));
}

void TestDomBuilder::TestAddAboveRoot()
{
  Builder = CreateBuilder("orders");
  ASSERT_NO_THROW(Builder->AddBelow("customer"));
  ASSERT_ANY_THROW(Builder->AddAbove("customer"));
}
