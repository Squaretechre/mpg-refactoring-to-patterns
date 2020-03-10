#ifndef TESTXMLBUILDER_H
#define TESTXMLBUILDER_H

#include <gtest/gtest.h>

#include "XmlBuilder.h"

class TestXmlBuilder : public testing::Test
{
public:
  void TestAddAboveRoot();
private:
  std::unique_ptr<XmlBuilder> Builder;
};

#endif