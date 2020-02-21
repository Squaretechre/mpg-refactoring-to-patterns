#include "TestXmlBuilder.h"

#include <gtest/gtest.h>

#include "XmlBuilder.h"

void TestXmlBuilder::TestAddAboveRoot()
{
  Builder = std::unique_ptr<XmlBuilder>(new XmlBuilder("orders"));
  ASSERT_NO_THROW(Builder->AddBelow("customer"));
  ASSERT_ANY_THROW(Builder->AddAbove("customer"));
}