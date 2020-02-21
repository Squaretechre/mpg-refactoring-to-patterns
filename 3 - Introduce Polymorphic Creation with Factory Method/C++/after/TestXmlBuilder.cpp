#include "TestXmlBuilder.h"

#include <gtest/gtest.h>

#include "XmlBuilder.h"

std::unique_ptr<IOutputBuilder> TestXmlBuilder::CreateBuilder(std::string root)
{
  return std::unique_ptr<IOutputBuilder>(new XmlBuilder(root));
}

void TestXmlBuilder::TestAddAboveRoot()
{
  Builder = CreateBuilder("orders");
  ASSERT_NO_THROW(Builder->AddBelow("customer"));
  ASSERT_ANY_THROW(Builder->AddAbove("customer"));
}