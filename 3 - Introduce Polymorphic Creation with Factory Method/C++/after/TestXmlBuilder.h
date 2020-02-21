#ifndef TESTXMLBUILDER_H
#define TESTXMLBUILDER_H

#include <gtest/gtest.h>

#include "IOutputBuilder.h"

class TestXmlBuilder : public testing::Test
{
public:
  void TestAddAboveRoot();
private:
  std::unique_ptr<IOutputBuilder> Builder;
  std::unique_ptr<IOutputBuilder> CreateBuilder(std::string root);
};

#endif