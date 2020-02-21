#ifndef TESTDOMBUILDER_H
#define TESTDOMBUILDER_H

#include <gtest/gtest.h>

#include "IOutputBuilder.h"

class TestDomBuilder : public testing::Test
{
public:
  void TestAddAboveRoot();
private:
  std::unique_ptr<IOutputBuilder> Builder;
  std::unique_ptr<IOutputBuilder> CreateBuilder(std::string root);
};

#endif